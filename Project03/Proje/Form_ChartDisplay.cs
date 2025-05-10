using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Project2;
using static System.Windows.Forms.AxHost;



namespace Project2
{




    public partial class Form_ChartDisplay : Form
    {



        // Initializing global variables for later use for mouse event functions
        private bool isDragging = false; // Flag for mouse down, move, and up
        private Point mouseDownLocation; // Gets coordinates for mouse down location
        private RectangleAnnotation rubberbandRectangle; // Rectangle annotation for rubberbanding
        private List<Annotation> fibonacciLines = new List<Annotation>(); // List of Fibonacci lines of the wave
        private LineAnnotation diagonalLine; // Diagonal line of the rubberband
        private List<Candlestick> selectedCandlesticks; // List of the candlesticks in a wave
        private DateTime dragStartDate; // Date of where mouse is down
        private DateTime dragEndDate; // Date of where mouse is up
        private decimal rectStart; // passed to yStart 
        private int dragStartIndex; // passed to xStart, however this starts at 0
        private int dragEndIndex; // not used, same as xEnd but starts at 0




        public Form_ChartDisplay()
        {
            // Initialize Form components
            InitializeComponent();
        }


        // Constructor for the chart display with 3 parameters: the file path, start date, end date
        public Form_ChartDisplay(String filePath, DateTime startDate, DateTime endDate)
        {
            // Initializes form components
            InitializeComponent();

            // Sets the start and end date pickers to the values
            dateTimePicker_StartDate.Value = startDate;
            dateTimePicker_EndDate.Value = endDate;

            // Loads the ticker from the specified file path
            LoadTicker(filePath);

            // Filter candlesticks based on start and end dates
            List<Candlestick> filteredCandlesticks = FilterCandlesticksByDate(candlesticks.ToList(), dateTimePicker_StartDate.Value, dateTimePicker_EndDate.Value);
            // Display filtered stock on chart
            displayStock(filteredCandlesticks);







        }


        // Creates a binding list of candlesticks called candlesticks
        private BindingList<Candlestick> candlesticks = new BindingList<Candlestick>();




        // Filters the candlesticks when the start date and end date is specified from DateTimePicker values
        private List<Candlestick> FilterCandlesticksByDate(List<Candlestick> candlesticks, DateTime startDate, DateTime endDate)
        {
            // Returns the list of candlesticks based on the specified date range
            return candlesticks.Where(c => c.Date >= startDate && c.Date <= endDate).ToList();
        }



        // Loads the files that are selected 
        private void LoadTicker(string filePath)
        {
            // Sets the name of the dialog window to the directory path
            Text = filePath;

            // Load the candlesticks and ensure they're sorted by date in ascending order (earliest to latest)
            candlesticks = new BindingList<Candlestick>(ReadCandlesticksFromCSV(filePath)
                .OrderBy(c => c.Date) // Ensure sorting here by date
                .ToList());

            // Call refreshDisplay() to refresh the chart when dates are changed
            refreshDisplay();


        }




        // Function to read the candlesticks from the CSV files and returns list of Candlestick objects
        public List<Candlestick> ReadCandlesticksFromCSV(string filePath)
        {
            // Creates new list of Candlesticks object to store data
            var candlestickList = new List<Candlestick>();

            // Opening the file for reading
            using (var reader = new StreamReader(filePath))
            {
                // Reads and ignore header (first line)
                var header = reader.ReadLine();
                // Loops until reaches the end of file
                while (!reader.EndOfStream)
                {
                    // Reads a line of data
                    var line = reader.ReadLine();
                    // Adds a line (that is converted to Candlestick object) to the list
                    candlestickList.Add(new Candlestick(line));
                }
            }

            // Returns the list of candlesticks
            return candlestickList;
        }


        // Displays stock data in the Chart control
        public void displayStock(List<Candlestick> listOfCandlesticks)
        {
            // Sort the list of candlesticks by date in ascending order
            var sortedCandlesticks = listOfCandlesticks.OrderBy(c => c.Date).ToList();

            // Binds the sorted stock data to the form
            bindingSource_Candlestick.DataSource = sortedCandlesticks;
            // Modifies chart scaling
            normalizeChart(sortedCandlesticks);

            // Gets the data for the Chart object
            chart_Candlestick.DataSource = sortedCandlesticks;
            // Binds the chart to the data 
            chart_Candlestick.DataBind();
        }


        // Adjust Y-axis of chart based on minimum and maximum candlestick values
        private void normalizeChart(List<Candlestick> candlesticks)
        {
            // If there is no data, exit function
            if (!candlesticks.Any()) return;

            // Gets maximum price in data
            decimal maxHigh = candlesticks.Max(c => c.High);
            // Gets minmum price in data
            decimal minLow = candlesticks.Min(c => c.Low);

            // Sets minimum of Y-axis 2% below lowest value
            chart_Candlestick.ChartAreas[0].AxisY.Minimum = (double)(minLow * 0.98m);
            // Sets maximum of Y-axis 2% above highest value
            chart_Candlestick.ChartAreas[0].AxisY.Maximum = (double)(maxHigh * 1.02m);
        }





        private void refreshDisplay()
        {

            // Checks if there is any candlestick data available
            if (candlesticks == null || candlesticks.Count == 0) return;

            // Filters the candlesticks by date range selected
            List<Candlestick> filteredCandlesticks = FilterCandlesticksByDate(candlesticks.ToList(), dateTimePicker_StartDate.Value, dateTimePicker_EndDate.Value);
            
            // Display the filtered candlesticks on the chart
            displayStock(filteredCandlesticks);

            // Creates a margin variable from scrollbar event
            int margin = hScrollBar_Margin.Value;
            // peakValleys stores all the peaks and valleys of the data of filtered candlesticks by margin
            var peakValleys = FindPeaksAndValleys(filteredCandlesticks, margin);
            // Draws the peak and valley annotations
            DrawPVAnnotations(peakValleys, filteredCandlesticks);
            // Detects up and down waves of the candlesticks
            DetectWaves(peakValleys);



        }





        // Event handler for when Refresh button is clicked
        private void button_Refresh_Click(object sender, EventArgs e)
        {
            // Calls refreshDisplay function to refresh the chart
            refreshDisplay();
        }

        // Event handler when the scrollbar is scrolled
        private void hScrollBar_Margin_Scroll(object sender, ScrollEventArgs e)
        {
            // Margin stores the scrollbar value
            int margin = hScrollBar_Margin.Value;
            // Displays the margin number in the textbox
            textBox_Margin.Text = margin.ToString();

            // Refreshes the display whenever the scrollbar is changed
            refreshDisplay();

        }







        // Finds all of the occurrences of the peaks and valley in regards to the margin chosen by the user
        private List<PeakValley> FindPeaksAndValleys(List<Candlestick> candlesticks, int margin)
        {

            // peakValleys is a list of type PeakValley
            var peakValleys = new List<PeakValley>();


            // Iterates through the candlesticks (that are filtered from the refreshDisplay())
            // .Count is a List property
            for (int i = 0; i < candlesticks.Count; i++)
            {

                // current keeps track of the candlestick that is being checked
                var current = candlesticks[i];


                

                // Checking for any LEFT PEAKS (from current) within margin
                // Set flag isPeak to true
                bool isPeak = true;

                // Maximum comparator for candlesticks that will go out of bounds if margin ends up below 0. j is either 0 or the leftmost index of margin
                // (for left out of bounds)
                // Iterates j until reaches i
                // j iterates through the left margin of the current candlestick
                for (int j = Math.Max(0, i - margin); j < i; j++)
                {
                    // To check if there is a candlestick in the left margin that is higher that current candlestick. (If so, current is not a Peak)
                    if (candlesticks[j].High >= current.High)
                    {
                        // current is not a Peak
                        isPeak = false;
                        // No need to check further
                        break;
                    }
                }

                // Checking for any RIGHT PEAKS (from current) within margin
                // current could still potentially be a Peak
                if (isPeak) 
                {
                    // j starts to the candlestick to the right of current
                    // j iterates until and on the number of margins to the right of current and if it doesn't reach the end of all the candlesticks
                    // (for right out of bounds)
                    for (int j = i + 1; j <= i+ margin && j < candlesticks.Count; j++)
                    {
                        // To check if there is a candlestick in the right margin that is higher that current candlestick. (If so, current is not a Peak)
                        if (candlesticks[j].High >= current.High)
                        {
                            // current is not a Peak
                            isPeak = false;
                            // No need to check further
                            break;
                        }
                    }
                }


                // Checking for any LEFT VALLEYS (from current) within margin
                // Set flag isValley to true
                bool isValley = true;

                // Maximum comparator for candlesticks that will go out of bounds if margin ends up below 0. j is either 0 or the leftmost index of margin
                // (for left out of bounds)
                // Iterates j until reaches i
                // j iterates through the left margin of the current candlestick
                for (int j = Math.Max(0, i - margin); j < i; j++)
                {
                    // To check if there is a candlestick in the left margin that is lower that current candlestick. (If so, current is not a Valley)
                    if (candlesticks[j].Low <= current.Low)
                    {
                        // current is not a Valley
                        isValley = false;
                        // No need to check further
                        break;
                    }
                }

                // Checking for any RIGHT VALLEYS (from current) within margin
                // current could still potentially be a Valley
                if (isValley) 
                {
                    // j starts to the candlestick to the right of current
                    // j iterates until and on the number of margins to the right of current and if it doesn't reach the end of all the candlesticks
                    // (for right out of bounds)

                    for (int j = i +1; j <= i + margin && j < candlesticks.Count; j++)
                    {
                        // To check if there is a candlestick in the right margin that is lower that current candlestick. (If so, current is not a Peak)
                        if (candlesticks[j].Low <= current.Low)
                        {
                            // current is not a Valley
                            isValley = false;
                            // No need to check further
                            break;
                        }
                    }
                }

                // If the ccurent candlestick is a peak or valley, add it to the list of PeakValley (peakValleys)
                // Remember that a candlestick can be both a peak and valley
                if (isPeak || isValley)
                {
                    // Adds a new object of type PeakValley to the list
                    peakValleys.Add(new PeakValley(i, margin, margin, isPeak, isValley));
                }
            }

            // Returns all of the peaks and valleys in the candlestick list (in regards to the selected margin)
            return peakValleys;
        }




        // Draws all the peaks and valleys with its respective margin
        private void DrawPVAnnotations(List<PeakValley> peakValleys, List<Candlestick> candlesticks)
        {
            // Clears all previous annotations
            chart_Candlestick.Annotations.Clear(); 

            // Iterates through each peak/valley
            foreach (var peakValley in peakValleys)
            {
                // Gets the candlestick by using its index
                var candlestick = candlesticks[peakValley.Index];

                // Gets the data point from the chart series by the index
                DataPoint anchorPoint = chart_Candlestick.Series[0].Points[peakValley.Index];

                // If the peak/valley is a PEAK
                if (peakValley.IsPeak)
                {
                    // Creates a Text Annotation for Peaks
                    var peakAnnotation = new TextAnnotation
                    {
                        // Sets text to "P"
                        Text = "P",
                        // Sets text color to Red
                        ForeColor = Color.Red,
                        // Font styles and size
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        // Sets data point to which annotation is anchored
                        AnchorDataPoint = anchorPoint,
                        // Move text above the peak
                        AnchorOffsetY = 5, 
                        // ALigns the annotation
                        Alignment = ContentAlignment.TopCenter,
                        
                    };
                    // Adds the annotation to the chart
                    chart_Candlestick.Annotations.Add(peakAnnotation);
                }

                // If the peak/valley is a VALLEY
                if (peakValley.IsValley)
                {
                    // Creates a Text Annotation for Valleys
                    var valleyAnnotation = new TextAnnotation
                    {
                        // Sets text to "V"
                        Text = "V",
                        // Sets text color to green
                        ForeColor = Color.Green,
                        // Font styles and size
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        // Sets data point to which annotation is anchored
                        AnchorDataPoint = anchorPoint,
                        // Move text below the valley
                        AnchorOffsetY = -5, 
                        // Aligns the annotation
                        Alignment = ContentAlignment.BottomCenter,
                        
                    };
                    // Adds the annotation to the chart
                    chart_Candlestick.Annotations.Add(valleyAnnotation);
                }
            }
        }







        // Validate the wave (all peak and valleys have to be in the bounds of the wave)
        private bool ValidWave(Candlestick start, Candlestick end, int startIndex, int endIndex, List<Candlestick> filteredCandlesticks, bool isUpWave)
        {

            // Validate the wave
            // No intermediate highs/lows 

            // Does not iterate on the first candlestick of the wave nor the last candlestick of the wave
            for (int i = startIndex + 1; i < endIndex; i++)
            {

                // between is a Candlestick from the list of filtered candlesticks. 
                // use 'between' to find any peaks/valleys between the start and end of the waves that are out of bounds
                var between = filteredCandlesticks[i];

                // If wave is valid up wave,
                // there should be no valley in the wave that is lower than the start's low and no peak higher than the end's high price
                if (isUpWave)
                {
                    
                    // Valid up wave, there should be no candlestick in the wave that is lower than the start's low and higher than the end's high price
                    if (between.Low < start.Low || between.High > end.High)
                    {

                        // Invalid up wave
                        return false; 
                    }
                }

                // If it's a down wave
                else
                {
                    // If wave is valid down wave,
                    // there should be no peak in the wave that is higher than the start's high and no valley lower than the end's low price
                    if (between.High > start.High || between.Low < end.Low)
                    {
                        // Invalid down wave
                        return false; 
                    }
                }
            }

            // Valid wave (passed all conditions)
            return true; 
        }






        // Creates a new list of up waves (of type Wave from Wave class)
        private List<Wave> upWaves = new List<Wave>();

        // Creates a new list of down waves(of type Wave from Wave class)
        private List<Wave> downWaves = new List<Wave>();




        private void DetectWaves(List<PeakValley> peakValleys)
        {
            // Clears all the up waves when refreshed
            upWaves.Clear();

            //Clears all the down waves when refreshed
            downWaves.Clear();

            // filteredCandlesticks is a list of Candlesticks within the date range that user has picked
            var filteredCandlesticks = FilterCandlesticksByDate(candlesticks.ToList(),
                                                dateTimePicker_StartDate.Value, dateTimePicker_EndDate.Value);


            // lastValley and lastPeak is a type PeakValley initalized to null
            // Used to decide whether to use up or down wave
            PeakValley lastValley = null;
            PeakValley lastPeak = null;



            // Loops through all of the peaks/valleys in the list of PeakValley
            // current is a candlestick that is either a Peak or a Valley or both // (using it to iterate)
            foreach (var current in peakValleys)
            {

                // if the current is a Valley (determined from FindPeaksAndValleys)
                if (current.IsValley)
                {

                    // If there is a previous peak, make a DOWN WAVE
                    if (lastPeak != null)
                    {

                        // startIndex is the index of either the rightmost/leftmost candlestick of the wave
                        int startIndex = lastPeak.Index;
                        // startIndex is the index of either the rightmost/leftmost candlestick of the wave
                        int endIndex = current.Index;


                        // To make sure the start index is the leftmost and endIndex is the rightmost candlestick of the wave
                        if (startIndex > endIndex)
                        {
                            // Swaps the values if the startIndex was initially greater than endIndex
                            (startIndex, endIndex) = (endIndex, startIndex);
                        }

                        // startCandlestick is a Peak that starts the (down)wave
                        var startCandlestick = filteredCandlesticks[startIndex];
                        // endCandlestick is a Valley that ends the (down)wave
                        var endCandlestick = filteredCandlesticks[endIndex];



                        // Check for VALID DOWN WAVE
                        // The peak should be higher than the valley
                        // There should be no intermediate higher peaks/lower valleys within the wave
                        if (startCandlestick.High > endCandlestick.Low && ValidWave(startCandlestick, endCandlestick, startIndex, endIndex, filteredCandlesticks, false))
                        {
                            // Add the valid down wave with respective arguments
                            downWaves.Add(new Wave(
                                startCandlestick.Date, endCandlestick.Date, false, startIndex, endIndex,
                                (double)startCandlestick.High, (double)startCandlestick.Low,
                                (double)endCandlestick.High, (double)endCandlestick.Low
                            ));
                        }
                    }
                    // Iterates the lastValley to the next Valley
                    lastValley = current;
                }

                // If the current is a Peak
                else if (current.IsPeak)
                {
                    // If there is a previous Valley, make an UP WAVE
                    if (lastValley != null)
                    {
                        // startIndex is the index of either the rightmost/leftmost candlestick of the wave
                        int startIndex = lastValley.Index;
                        // startIndex is the index of either the rightmost/leftmost candlestick of the wave
                        int endIndex = current.Index;


                        // To make sure the start index is the leftmost and endIndex is the rightmost candlestick of the wave
                        if (startIndex > endIndex)
                        {
                            // Swaps the values if the startIndex was initially greater than endIndex
                            (startIndex, endIndex) = (endIndex, startIndex);
                        }

                        // startCandlestick is a Valley that starts the (up)wave
                        var startCandlestick = filteredCandlesticks[startIndex];
                        // endCandlestick is a Velley that ends the (up)wave
                        var endCandlestick = filteredCandlesticks[endIndex];


                        // Check for VALID UP WAVE
                        // The peak should be higher than the valley
                        // There should be no intermediate higher peaks/lower valleys within the wave
                        if (startCandlestick.Low < endCandlestick.High && ValidWave(startCandlestick, endCandlestick, startIndex, endIndex, filteredCandlesticks, true))
                        {
                            // Add the valid up wave with respective arguments
                            upWaves.Add(new Wave(
                                startCandlestick.Date, endCandlestick.Date, true, startIndex, endIndex,
                                (double)startCandlestick.High, (double)startCandlestick.Low,
                                (double)endCandlestick.High, (double)endCandlestick.Low
                            ));
                        }
                    }
                    // Iterates the lastPeak to the next Peak
                    lastPeak = current; 
                }
                
                // current is iterated
            }


            // Clears any up and down waves in the drop down if refreshed
            comboBox_UpWaves.Items.Clear();
            comboBox_DownWaves.Items.Clear();


            // Update drop down boxes with valid up waves and down waves
            comboBox_UpWaves.Items.AddRange(upWaves.ToArray());
            comboBox_DownWaves.Items.AddRange(downWaves.ToArray());
        }




        // Global variables for waves 
        private int xStart; // x index of the filtered candlesticks by date of the start of the rectangle
        private int xEnd; // x index of the filtered candlesticks by date of the end of the rectangle
        private double yStart; // Price at which the wave starts
        private double yEnd; // Price at which the wave ends

        private RectangleAnnotation rectWave; // Rectangle annotation for combobox waves
        private LineAnnotation waveLine; // Line annotation for diagonal line for combobox waves

        // To distinguish combobox waves from manually drawn waves
        private enum WaveMode { None, Manual, Dropdown }
        private WaveMode currentWaveMode = WaveMode.None;



        // Draws the wave
        private void DrawWaveAnnotation(Chart chart_Candlestick, Wave wave)
        {
            // Clears all previous annotations
            chart_Candlestick.Annotations.Clear();
            chart_Candlestick.Invalidate();

            // Filters to only the candlesticks in the wave
            selectedCandlesticks = FilterCandlesticksByDate(candlesticks.ToList(), wave.StartDate, wave.EndDate);

            // yEnd is either the end's high if up wave, or end's low if down wave
            yEnd = wave.IsUpWave ? wave.EndHigh : wave.EndLow;
            // yStart is either start's low if up wave, or start's high if down wave
            yStart = wave.IsUpWave ? wave.StartLow : wave.StartHigh;


            // Draws the confirmations
            DrawConfirmations((decimal)yStart, yEnd, selectedCandlesticks);

            // Get start and end points
            xStart = wave.StartIndex + 1;
            xEnd = wave.EndIndex + 1;



            // Draws the Fibonacci Lines
            DrawFibonacci(xStart, yStart, xEnd, yEnd);




            // Define chartArea for use of setting axis
            var chartArea = chart_Candlestick.ChartAreas["ChartArea_OHLC"];




            // Annotation coords start at top left corner
            rectWave = new RectangleAnnotation
            {

                // Sets x axis to the chart's x axis
                AxisX = chartArea.AxisX,
                // Sets y axis to the chart's y axis
                AxisY = chartArea.AxisY,

                // X coord of rectangle starts at the start index of candlesticks
                X = xStart,
                // Y coord of rectangle starts at either start's high or end's high (depending whether it's an up wave or down wave)
                Y = yStart,

                // Width of rectangle is the difference of start index and end index
                Width = (xEnd - xStart),

                // Height of the rectangle (computation differs for up/down waves)
                Height = -(yStart-yEnd),

                // Color of the wave rectangle depending on up/down wave
                LineColor = wave.IsUpWave ? Color.Green : Color.Red,

                // Green/red transparant rectangle
                BackColor = wave.IsUpWave ? Color.FromArgb(50, 0, 255, 0) : Color.FromArgb(50, 255, 0, 0),

                // Width of rectangle border
                LineWidth = 2,


                // Chart coordinates are not relative to the size of chart
                IsSizeAlwaysRelative = false



            };
            // Adds the annotation to the chart
            chart_Candlestick.Annotations.Add(rectWave);



            // Create Line Annotation (Diagonal wave line)
            waveLine = new LineAnnotation
            {
                // Sets x axis to the chart's x axis
                AxisX = chartArea.AxisX,
                // Sets y axis to the chart's y axis
                AxisY = chartArea.AxisY,

                // X coord of line starts at the start index of candlesticks
                X = xStart,
                // Y coord of line starts at either start's high or start's low(depending whether it's an up wave or down wave)
                Y = yStart,

                // Width of line is the difference of start index and end index
                Width = Math.Abs(xEnd - xStart),

                // Height of the line (computation differs for up/down waves)
                Height = -(yStart - yEnd),

                // Color of the wave rectangle depending on up/down wave
                LineColor = wave.IsUpWave ? Color.Green : Color.Red,

                // Width of rectangle border
                LineWidth = 2,

                // Chart coordinates are not relative to the size of chart
                IsSizeAlwaysRelative = false


            };
            // Adds the annotation to the chart
            chart_Candlestick.Annotations.Add(waveLine);

            chart_Candlestick.Invalidate();


        }




 
        

        // Event handler for up wave combobox
        private void comboBox_UpWaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart_Candlestick.Invalidate();

            
            // The selected item from the combobox
            var selectedItem = comboBox_UpWaves.SelectedItem;

            // Distinguish wave mode
            currentWaveMode = WaveMode.Dropdown;


            // If it's type Wave
            if (selectedItem is Wave)
            {
                // Casts the selected item to a Wave object
                Wave selectedWave = (Wave)selectedItem;


                // Draws the up wave that has been selected from the drop down
                DrawWaveAnnotation(chart_Candlestick, selectedWave);
                

            }
        }

        // Event handler for down wave combobox
        private void comboBox_DownWaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart_Candlestick.Invalidate();
            // The selected item from the combobox
            var selectedItem = comboBox_DownWaves.SelectedItem;

            // Distinguish wave mode
            currentWaveMode = WaveMode.Dropdown;


            // If item is type Wave
            if (selectedItem is Wave)
            {
                // Casts the selected item to a Wave object
                Wave selectedWave = (Wave)selectedItem;

                // Draws the down wave that has been selected from the drop down
                DrawWaveAnnotation(chart_Candlestick, selectedWave);
                


            }
        }


        // Project 3


        private void chart_Candlestick_MouseDown(object sender, MouseEventArgs e)
        {

            // Flag to see if mouse is pressed or not
            isDragging = true;
            // The point at which mouse is pressed
            mouseDownLocation = e.Location;

            // Filters candlesticks by the date time pickers
            var filteredCandlesticks = FilterCandlesticksByDate(candlesticks.ToList(), dateTimePicker_StartDate.Value, dateTimePicker_EndDate.Value);

            // Get starting date from pixel location
            dragStartDate = DateFromPixel(e.X, dateTimePicker_StartDate.Value, dateTimePicker_EndDate.Value);

            // find index of dragStartDate relative to the filtered list
            dragStartIndex = filteredCandlesticks.FindIndex(c => c.Date == dragStartDate);

            
            // Clears annotations
            chart_Candlestick.Annotations.Clear();
            fibonacciLines.Clear();

            // List of peak and valleys in the candlesticks list
            var peakValleys = FindPeaksAndValleys(filteredCandlesticks.ToList(), hScrollBar_Margin.Value);



            PeakValley matchingPV = null;
            
            // Iterates through each peak/valley in the list of peaks and valleys 
            foreach (var pv in peakValleys)
            {
                // Takes the candlestick by the index of the peak/valley
                var candlestick = filteredCandlesticks[pv.Index];

                // Checks if the index of the list of peaks and valleys checks the index of the index of the start (of the mouse down) index
                if (pv.Index == dragStartIndex) 
                {
                    matchingPV = pv;

                    // Debugging purposes... if it's a valley, it starts an upwave, if it's a peak, it starts a downwave
                    bool startsUpWave = pv.IsValley && upWaves.Any(w => w.StartDate == candlestick.Date);
                    bool startsDownWave = pv.IsPeak && downWaves.Any(w => w.StartDate == candlestick.Date);


                    // If valley
                    if (pv.IsValley)
                    {
                        // Rectangle starts at the candlestick's low
                        rectStart = candlestick.Low;
                    }
                    // IF peak
                    else if (pv.IsPeak)
                    {
                        // Rectangle starts at the candlestick's high
                        rectStart = candlestick.High;
                    }

                    break;
                }
            }

            // If the candlestick is not a peak or a valley
            if (matchingPV == null)
            {
                // If the mouse down is at a candlestick that is not a peak nor a valley
                MessageBox.Show("The selected starting point is not a peak or valley.\nPlease start your selection on a valid point.",
                                "Invalid Selection",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                // Refresh display to clear any invalid selections
                isDragging = false;
                
                chart_Candlestick.Invalidate();
                
                
            }


            // Rectangle annotation for rubberbanding
            rubberbandRectangle = new RectangleAnnotation
            {
                AxisX = chart_Candlestick.ChartAreas[0].AxisX,
                AxisY = chart_Candlestick.ChartAreas[0].AxisY,
                LineColor = Color.Blue,
                BackColor = Color.FromArgb(50, Color.LightBlue),
                ClipToChartArea = chart_Candlestick.ChartAreas[0].Name,
                IsSizeAlwaysRelative = false,
            };
            // Adds the rubberband rectangle to the chart
            chart_Candlestick.Annotations.Add(rubberbandRectangle);
   

        }





        private void chart_Candlestick_MouseMove(object sender, MouseEventArgs e)
        {
            // While the mouse is dragging
            if (isDragging)
            {
                
                // xStart is the index at which the selections of the rubberband starts 
                xStart = dragStartIndex + 1; 
                // yStart is the value at which the wave starts
                yStart = (double)rectStart;
                // xEnd is the index at which the mouse is at while dragging
                xEnd = (int)chart_Candlestick.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                // yEnd is the price at which the mouse is at while dragging
                yEnd = chart_Candlestick.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);

                // Draw Fibonacci lines
                DrawFibonacci(xStart, yStart, xEnd, yEnd);


                // Remove previous diagonal line if any
                if (diagonalLine != null)
                    chart_Candlestick.Annotations.Remove(diagonalLine);

                // Create diagonal line from start to end of drag
                diagonalLine = new LineAnnotation
                {
                    AxisX = chart_Candlestick.ChartAreas[0].AxisX,
                    AxisY = chart_Candlestick.ChartAreas[0].AxisY,
                    IsSizeAlwaysRelative = false,
                    ClipToChartArea = chart_Candlestick.ChartAreas[0].Name,
                    LineColor = Color.Blue,
                    LineWidth = 2,
                    X = xStart, // Start of diagonal line is at xStart
                    Y = yStart, // Start of diagonal line is at yStart
                    Width = Math.Abs(xEnd - xStart) * (xEnd >= xStart ? 1 : -1), // Width of the diagonal line
                    Height = (yEnd - yStart) // Height of the diagonal line
                };
                chart_Candlestick.Annotations.Add(diagonalLine);


                // Fix rectangle to match the top and bottom Y levels 
                rubberbandRectangle.X = Math.Min(xStart, xEnd); // x coord of where rectangle is drawn
                rubberbandRectangle.Y = yStart; // y coord of where rectangle is drawn
                rubberbandRectangle.Width = Math.Abs(xEnd - xStart); // Changes the width of the rectangle live
                rubberbandRectangle.Height = yEnd - yStart; // Changes the height of the rectangle live

                chart_Candlestick.Invalidate();
            }
            // Displays current price
            textBox_HighLowPrice.Text = yEnd.ToString();

        }





        private void chart_Candlestick_MouseUp(object sender, MouseEventArgs e)
        {
            // To distinguish between wave selections
            currentWaveMode = WaveMode.Manual;

            // Mouse is no longer dragging
            isDragging = false;

            // Updates yEnd to where the mouse ended up
            yEnd = chart_Candlestick.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);

            // filteredCandlesticks are all candlesticks that are displayed on the form
            var filteredCandlesticks = FilterCandlesticksByDate(candlesticks.ToList(), dateTimePicker_StartDate.Value, dateTimePicker_EndDate.Value);

            // Get the end date based on mouse position
            dragEndDate = DateFromPixel(e.X, dateTimePicker_StartDate.Value, dateTimePicker_EndDate.Value);



            // Making sure dates are in order: dragStartDate should be earlier than dragEndDate
            DateTime start = dragStartDate < dragEndDate ? dragStartDate : dragEndDate;
            DateTime end = dragStartDate > dragEndDate ? dragStartDate : dragEndDate;

            // If the user drags the mouse (wave) to a date earlier in which mouse down was, invalid
            if (dragStartDate > dragEndDate)
            {
                Console.WriteLine("Invalid");
                MessageBox.Show("Invalid", "",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }

            

            // Filter candlesticks based on the selected date range
            selectedCandlesticks = FilterCandlesticksByDate(candlesticks.ToList(), start, end);


            // upWaves and downWaves are lists of 'Wave' objects 
            // Flag for upwave
            bool isUpWave = false;
            
            // wave is a Wave object, iterating through the upWaves list
            foreach (var wave in upWaves)
            {
                isUpWave = false;
                // If wave's start date == start and end date == end, is upwave
                if (wave.StartDate == dragStartDate && wave.EndDate == dragEndDate)
                {
                    Console.WriteLine($"Valid upwave");
                    isUpWave = true;
                    break;
                }
                // If iterated through the upWaves list and no wave matched, it isn't an upwave
                else if (wave == upWaves.Last())
                {
                    isUpWave = false;
                    Console.WriteLine($"Invalid");
                    //MessageBox.Show("Invalid", "",
                    //MessageBoxButtons.OK,
                    //MessageBoxIcon.Warning);

                    break;
                    
                }

            }


            
            if (isUpWave == false)
            {
                // wave is a Wave object, iterating through the downWaves list
                foreach (var wave in downWaves)
                {
                    // if wave's start date == start and end date == end, is downwave
                    if (wave.StartDate == dragStartDate && wave.EndDate == dragEndDate)
                    {
                        Console.WriteLine($"Valid downwave");
                        break;
                    }

                    // If iterated through the list adownWaves and no wave matched, it isn't an upwave
                    else if (wave == downWaves.Last())
                    {
                        Console.WriteLine($"Invalid");

                        //MessageBox.Show("Invalid", "",
                        //MessageBoxButtons.OK,
                        //MessageBoxIcon.Warning);
                        break;
                        
                    }
                   
                }

            }
            // Draws confirmations 
            DrawConfirmations((decimal)yStart, yEnd, selectedCandlesticks);
        }



        // Function to convert the pixel on the chart to the corresponding date of the chart (based on x coordinate)
        private DateTime DateFromPixel(int pixelX, DateTime startDate, DateTime endDate)
        {
            // Converts pixel position to the corresponding value on the X axis
            double valueX = chart_Candlestick.ChartAreas[0].AxisX.PixelPositionToValue(pixelX);

            // Round to nearest integer index and get corresponding candlestick index
            int index = (int)Math.Round(valueX) - 1;

            // Filter the candlesticks by date range (startDate to endDate)
            var filteredCandlesticks = candlesticks
                .Where(c => c.Date >= startDate && c.Date <= endDate)
                .ToList();

            // If the index is valid within the filtered candlesticks range
            if (index >= 0 && index < filteredCandlesticks.Count)
            {
                return filteredCandlesticks[index].Date;
            }

            // If the index is out of range, return the first or last valid date in the filtered list
            // Return startDate if no valid date is found
            return filteredCandlesticks.FirstOrDefault()?.Date ?? startDate;  
        }


        
        // List of dots (confirmations)
        private List<TextAnnotation> dotsList = new List<TextAnnotation>();

        // Function to calculate and draw confirmations
        private void DrawConfirmations(decimal rectStart, double yEndPrice, List<Candlestick> enclosedCandlesticks)
        {

            // Remove all previous dot annotations
            foreach (var dots in dotsList)
                chart_Candlestick.Annotations.Remove(dots);
            dotsList.Clear();


            // Filters candlesticks by date time picker dates
            var filteredCandlesticks = FilterCandlesticksByDate(candlesticks.ToList(), dateTimePicker_StartDate.Value, dateTimePicker_EndDate.Value);

            // If no selection, don't draw confirmations or count confirmations
            if (enclosedCandlesticks == null || enclosedCandlesticks.Count == 0)
                return;

            // Compute wave range
            double waveRange = (double)Math.Abs(yEndPrice - (double)rectStart);
            // 1.5% tolerance
            double tolerance = waveRange * 0.015;

            // Define Fibonacci levels (100% to 0%)
            double[] levels = { 1.0, 0.764, 0.618, 0.5, 0.382, 0.236, 0.0 };

            // Number of confirmations
            int hitCount = 0;

            // Create Fibonacci lines at each level
            foreach (double level in levels)
            {
                // Price at the fibonacci level
                double fibPrice = (double)rectStart + (double)(yEndPrice - (double)rectStart) * (1 - level);
                // The bounds of the fibonacci level prices to count for a confirmation
                double lower = fibPrice - tolerance;
                double upper = fibPrice + tolerance;
                
                // Iterates through each candle in the selection
                foreach (var candle in enclosedCandlesticks)
                {
                    // If the level hits the candle at any OHLC, count it as a confirmation
                    if ((double)candle.Open >= lower && (double)candle.Open <= upper ||
                        (double)candle.High >= lower && (double)candle.High <= upper ||
                        (double)candle.Low >= lower && (double)candle.Low <= upper ||
                        (double)candle.Close >= lower && (double)candle.Close <= upper)
                    {
                        // Increments confirmations
                        hitCount++;

                        // Draw a dot at the price level
                        int x = filteredCandlesticks.IndexOf(candle) + 1;

                        RectangleAnnotation dot = new RectangleAnnotation
                        {
                            
                            X = x - 0.05,
                            AnchorY = fibPrice,
                            ForeColor = Color.DarkBlue,
                            LineColor = Color.DarkBlue,
                            BackColor = Color.DarkBlue,
                            ClipToChartArea = chart_Candlestick.ChartAreas[0].Name,

                            Width = 0.09,
                            Height = 0.25,

                            AxisX = chart_Candlestick.ChartAreas[0].AxisX,
                            AxisY = chart_Candlestick.ChartAreas[0].AxisY,

                            IsSizeAlwaysRelative = false,
                            AnchorAlignment = ContentAlignment.MiddleCenter,  
                            
                        };

                        chart_Candlestick.Annotations.Add(dot);
                        // Adds the confirmation to the list of confirmations
                        dotsList.Add(dot);
                        
                    }
                }
            }

            
            // Updates confirmations and current price text boxes
            textBox_Confirmations.Text = hitCount.ToString();
            textBox_HighLowPrice.Text = yEnd.ToString();

            chart_Candlestick.Invalidate();
        }



        private void DrawFibonacci(double xStart, double yStart, double xEnd, double yEnd)
        {
            // Remove old Fibonacci lines
            foreach (var line in fibonacciLines)
                chart_Candlestick.Annotations.Remove(line);
            fibonacciLines.Clear();

            // Fibonacci levels from 100% to 0%
            double[] levels = { 1.0, 0.764, 0.618, 0.5, 0.382, 0.236, 0.0 };
            


            // Create Fibonacci lines at each level
            foreach (double level in levels)
            {
                // Calculate the Y value for the Fibonacci level
                double yLevel = yStart + (yEnd - yStart) * (1 - level);

                // Create a line annotation for this level
                LineAnnotation fibLine = new LineAnnotation
                {
                    AxisX = chart_Candlestick.ChartAreas[0].AxisX,
                    AxisY = chart_Candlestick.ChartAreas[0].AxisY,
                    IsSizeAlwaysRelative = false,
                    ClipToChartArea = chart_Candlestick.ChartAreas[0].Name,
                    LineColor = Color.Purple,
                    LineDashStyle = ChartDashStyle.Dash,
                    X = Math.Min(xStart, xEnd),
                    Width = Math.Abs(xEnd - xStart),
                    Y = yLevel,
                    Height = 0
                };

                // Add the Fibonacci line to the chart
                chart_Candlestick.Annotations.Add(fibLine);
                fibonacciLines.Add(fibLine);
            }

            // Update the chart display
            chart_Candlestick.Invalidate();
        }





        // Stores starting yEnd value before iteration starts
        private double initialYEnd;

        // Stores the user's percent bound for how far yEnd can move from initialYEnd
        private double percentBound;

        private double PercentageIterate(double percentStep)
        {
            // Price range of the wave
            double waveRange = Math.Abs(yEnd - yStart);

            // Step size for each iteration
            double stepSize = waveRange * percentStep / 100;

            // Maximum/minimum amount yEnd can be when simulation happens
            double boundSize = waveRange * percentBound / 100;

            // If step size is larger than the allowed range, not allowed
            if (percentStep > percentBound) return 0;

            // Max and min bounds
            double yMax = initialYEnd + boundSize;
            double yMin = initialYEnd - boundSize;


            // Prevent stepping beyond the maximum
            if (yEnd + stepSize > yMax && yEnd > initialYEnd)
                return 0;
            // Prevent stepping beyond the minimum
            if (yEnd - stepSize < yMin && yEnd < initialYEnd)
                return 0;

            return stepSize;
        }





        private void timer_Simulate_Tick(object sender, EventArgs e)
        {
            // Refreshes percent bound on every clock tick
            percentBound = hScrollBar_PercentageRange.Value;

            // Step size
            double step = PercentageIterate(hScrollBar_PercentageIterate.Value);

            // Wave range and bounds (from percentage of user-defined)
            double waveRange = Math.Abs(yStart - initialYEnd);
            double bound = waveRange * percentBound / 100.0;

            // y bounds
            double upperBound = initialYEnd + bound;
            double lowerBound = initialYEnd - bound;

            bool isUpwardWave = yEnd > yStart;

            if (isUpwardWave)
            {
                if (yEnd + step <= upperBound)
                {
                    yEnd += step;

                    // Adjust the heights of the rubberband rectangle and diagonal line
                    if (currentWaveMode == WaveMode.Manual)
                    {
                        rubberbandRectangle.Height += step;
                        diagonalLine.Height += step;
                    }
                    // Adjust the heights of the dropdown waves rectangles and their diagonal line
                    else if (currentWaveMode == WaveMode.Dropdown)
                    {
                        rectWave.Height += step;
                        waveLine.Height += step;
                    }
                }

                // Stop the timer when bounds are hit, enable plus and minus buttons
                else
                {
                    timer_Simulate.Stop();
                    button_Simulate.Text = "Start";
                    button_Plus.Enabled = true;
                    button_Minus.Enabled = true;
                }
            }
            else // Downward wave
            {
                if (yEnd - step >= lowerBound)
                {
                    yEnd -= step;

                    // Adjust the heights of the rubberband rectangle and diagonal line
                    if (currentWaveMode == WaveMode.Manual)
                    {
                        rubberbandRectangle.Height -= step;
                        diagonalLine.Height -= step;
                    }
                    // Adjust the heights of the dropdown waves rectangles and their diagonal line
                    else if (currentWaveMode == WaveMode.Dropdown)
                    {
                        rectWave.Height -= step;
                        waveLine.Height -= step;
                    }
                }
                // Stop the timer when bounds are hit, enable plus and minus buttons
                else
                {
                    timer_Simulate.Stop(); 
                    button_Simulate.Text = "Start";
                    button_Plus.Enabled = true;
                    button_Minus.Enabled = true;
                }
            }

            // Draw Fibonacci levels and confirmations based on the updated values
            DrawFibonacci(xStart, yStart, xEnd, yEnd);
            DrawConfirmations((decimal)yStart, yEnd, selectedCandlesticks);
            textBox_HighLowPrice.Text = yEnd.ToString();
        }




        private void button_Simulate_Click(object sender, EventArgs e)
        {
            if (!timer_Simulate.Enabled)
            {
                // Save starting yEnd before simulation
                initialYEnd = yEnd;
                // Timer starts
                timer_Simulate.Start();
                button_Simulate.Text = "Stop";
                // Disable other buttons
                button_Plus.Enabled = false;
                button_Minus.Enabled = false;
            }
            else
            {
                // Timer stops
                timer_Simulate.Stop();
                button_Simulate.Text = "Start";
                // Enable other buttons
                button_Plus.Enabled = true;
                button_Minus.Enabled = true;
            }
        }





        private void button_Plus_Click(object sender, EventArgs e)
        {

            percentBound = hScrollBar_PercentageRange.Value;
            // Capture initial y value for bounds
            initialYEnd = yEnd;  

            double step = PercentageIterate(hScrollBar_PercentageIterate.Value);
            double waveRange = Math.Abs(yStart - initialYEnd);
            double bound = waveRange * percentBound / 100.0;
            double upperBound = initialYEnd + bound;

            if (yEnd + step <= upperBound)
            {
                yEnd += step;

                DrawFibonacci(xStart, yStart, xEnd, yEnd);
                DrawConfirmations((decimal)yStart, yEnd, selectedCandlesticks);

                // Adds the step size for manually-drawn wave
                if (currentWaveMode == WaveMode.Manual)
                {
                    rubberbandRectangle.Height += step;
                    diagonalLine.Height += step;
                }
                // Adds the step size for selected wave
                else if (currentWaveMode == WaveMode.Dropdown)
                {
                    rectWave.Height += step;
                    waveLine.Height += step;
                }
                // Updates current price textbox
                textBox_HighLowPrice.Text = yEnd.ToString();
            }
        }


        private void button_Minus_Click(object sender, EventArgs e)
        {
            percentBound = hScrollBar_PercentageRange.Value;
            // Capture initial y value for bounds
            initialYEnd = yEnd;  

            double step = PercentageIterate(hScrollBar_PercentageIterate.Value);
            double waveRange = Math.Abs(yStart - initialYEnd);
            double bound = waveRange * percentBound / 100.0;
            double lowerBound = initialYEnd - bound;

            if (yEnd - step >= lowerBound)
            {
                yEnd -= step;

                DrawFibonacci(xStart, yStart, xEnd, yEnd);
                DrawConfirmations((decimal)yStart, yEnd, selectedCandlesticks);

                // Subtracts the step size for manually-drawn wave
                if (currentWaveMode == WaveMode.Manual)
                {
                    rubberbandRectangle.Height -= step;
                    diagonalLine.Height -= step;
                }
                // Subtracts the step size for selected wave
                else if (currentWaveMode == WaveMode.Dropdown)
                {
                    rectWave.Height -= step;
                    waveLine.Height -= step;
                }

                // Updates current price textbox
                textBox_HighLowPrice.Text = yEnd.ToString();
            }
        }


        private void hScrollBar_PercentageIterate_Scroll(object sender, ScrollEventArgs e)
        {
            // Updates textbox based on scroll bar value
            textBox_PercentageIterate.Text = hScrollBar_PercentageIterate.Value.ToString();
            
        }

        private void hScrollBar_PercentageRange_Scroll(object sender, ScrollEventArgs e)
        {
            // Updates textbox based on scroll bar value
            textBox_PercentageRange.Text = hScrollBar_PercentageRange.Value.ToString();
        }





    }
}


