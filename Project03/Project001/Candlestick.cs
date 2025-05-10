using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization; // To format parsing dates and numbers


namespace Project001
{
    // Candlestick class (OHLCV properties)
    public class Candlestick
    {
        // Date property for the candlestick data
        public DateTime Date { get; set; }
        // Open price property for the candlestick data
        public decimal Open { get; set; }
        // High price property for the candlestick data
        public decimal High { get; set; }
        // Low price property for the candlestick data
        public decimal Low { get; set; }
        // Close price property for the candlestick data
        public decimal Close { get; set; }
        // Volume property for the candlestick data
        public decimal Volume { get; set; }

        // Candlestick constructor to initialize Candlestick object
        public Candlestick(DateTime date, decimal open, decimal high, decimal low, decimal close, decimal volume)
        {
            // Stores the date to Date property
            Date = date;
            // Stores the open price to the Open property
            Open = open;
            // Stores the high price to the High property
            High = high;
            // Stores the low price to the Low property
            Low = low;
            // Stores the close price to the Close property
            Close = close;
            // Stores the volume to the Volume property
            Volume = volume;
        }

        // Candlestick constructor to initialize Candlestick object from a CSV-formatted string
        public Candlestick(string data)
        {
            // Splitting the input string with delimiters
            var separators = new char[] { ',', '\"' };
            // Splitting input string into values
            var values = data.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            // If the input string does not contain 6 values, throw an exception
            if (values.Length != 6)
            {
                // Throws an exception/error if the format is invalid
                throw new ArgumentException("Invalid data format. Expected 5 values separated by commas.");
            }


            // Parses the values and stores it in the properties
            // Parses first value as DateTime object with specified format
            Date = DateTime.ParseExact(values[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);
            // Parses second value and rounds opening price to 2 decimal places
            Open = Math.Round(decimal.Parse(values[1]), 2);
            // Parses third value and rounds high price to 2 decimal places
            High = Math.Round(decimal.Parse(values[2]), 2);
            // Parses fourth value and rounds low price to 2 decimal places
            Low = Math.Round(decimal.Parse(values[3]), 2);
            // Parses fifth value and rounds closing price to 2 decimal places
            Close = Math.Round(decimal.Parse(values[4]), 2);
            // Parses sixth value (volume) as unsigned long integer
            Volume = ulong.Parse(values[5]);
        }

        // Overrides ToString() method to return formatted Candlestick object
        public override string ToString()
        {
            // Returns string of formatted properties of Candlestick object
            return $"Date:, {Date}, Open: {Open}, High: {High}, Low: {Low}, Close: {Close}, Volume: {Volume}";
        }
    }

}
