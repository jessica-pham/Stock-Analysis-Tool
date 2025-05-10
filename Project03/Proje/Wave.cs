


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class Wave
    {
        public DateTime StartDate { get; set; } // Start date with type DateTime
        public DateTime EndDate { get; set; } // End date with type DateTime
        public bool IsUpWave { get; set; } // true = up wave, false = down wave
        public int StartIndex { get; set; } // Index of start candlestick
        public int EndIndex { get; set; } // Index of end candlestick
        public double StartHigh { get; set; } // High value at start
        public double StartLow { get; set; } // Low value at start
        public double EndHigh { get; set; } // High value at end
        public double EndLow { get; set; } // Low value at end

        // Constructor for Wave
        public Wave(DateTime startDate, DateTime endDate, bool isUpWave,
                    int startIndex, int endIndex,
                    double startHigh, double startLow,
                    double endHigh, double endLow)
        {
            StartDate = startDate;
            EndDate = endDate;
            IsUpWave = isUpWave;
            StartIndex = startIndex;
            EndIndex = endIndex;
            StartHigh = startHigh;
            StartLow = startLow;
            EndHigh = endHigh;
            EndLow = endLow;

        }

        // Override ToString() for display in ComboBox
        public override string ToString()
        {
            return $"{StartDate.ToShortDateString()} - {EndDate.ToShortDateString()}";
        }
    }
}
