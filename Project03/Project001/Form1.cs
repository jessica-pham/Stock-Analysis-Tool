using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace Project001
{
    // Partial class for Form1 (a Windows Form)
    public partial class Form1 : Form
    {
        // Creates a Candlestick object named candlesticks to store the data from CSV file
        private List<Candlestick> candlesticks = new List<Candlestick>();

        // Form1 constructor
        public Form1()
        {
            // Initialize form components
            InitializeComponent();
        }

        // Event handler for button_LoadTicker click event
        private void button_LoadTicker_Click(object sender, EventArgs e)
        {
            // Opens file dialog to select a CSV file
            openFileDialog_LoadTicker.ShowDialog();
        }

        // Filters the candlesticks when the start date and end date is specified from DatTimePicker values
        private List<Candlestick> FilterCandlesticksByDate(List<Candlestick> candlesticks, DateTime startDate, DateTime endDate)
        {
            // Returns the list of candlesticks based on the specified date range
            return candlesticks.Where(c => c.Date >= startDate && c.Date <= endDate).ToList();
        }

        // Event handler that handles when a file is selected in the file dialog
        private void openFileDialog_LoadTicker_FileOk(object sender, CancelEventArgs e)
        {
            // Stores selected file path into filePath 
            string filePath = openFileDialog_LoadTicker.FileName;
            // Display file path into form's title
            Text = filePath;
            
            // Reads the candlestick data from file and stores into 'candlesticks'
            candlesticks = ReadCandlesticksFromCSV(filePath);

            // Filters the candlesticks by date specified
            List<Candlestick> filteredCandlesticks = FilterCandlesticksByDate(candlesticks, dateTimePicker_StartDate.Value, dateTimePicker_EndDate.Value);

            // Displays filtered data on form
            displayStock(filteredCandlesticks);
        }

        // Function to read the candlesticks from the CSV files and returns list of Candlestick objects
        public List<Candlestick> ReadCandlesticksFromCSV(string filePath)
        {
            // Creates new list of Candlesticks object to store data
            var candlesticks = new List<Candlestick>();

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
                    candlesticks.Add(new Candlestick(line));
                }
            }
            
            // Returns the list of candlesticks
            return candlesticks;
        }


        // Displays stock data in the Chart control
        public void displayStock(List<Candlestick> listOfCandlesticks)
        {
            // Binds the stock data to the form
            candlestickBindingSource.DataSource = listOfCandlesticks;
            // Modifies chart scaling
            normalizeChart(listOfCandlesticks);

            // Gets the data for the Chart object
            chart_Candlestick.DataSource = listOfCandlesticks;
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


        // Resets the chart display when refresh button is clicked and date range is modified
        private void refreshDisplay()
        {
            // If no data is selected, exit function
            if (candlesticks == null || candlesticks.Count == 0)
                return;

            // Re-filter the candlesticks based on the selected date range
            List<Candlestick> filteredCandlesticks = FilterCandlesticksByDate(candlesticks, dateTimePicker_StartDate.Value, dateTimePicker_EndDate.Value);

            // Redisplays stock chart with the filtered data
            displayStock(filteredCandlesticks);
        }


        // Event handler for when Refresh button is clicked
        private void button_Refresh_Click(object sender, EventArgs e)
        {
            // Calls refreshDisplay function to refresh the chart
            refreshDisplay();
        }
    }
}


