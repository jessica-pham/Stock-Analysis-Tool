using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class PeakValley
    {
        // Position in the candlestick list
        public int Index { get; set; }
        // Left margin
        public int LMargin { get; set; }
        // Right margin
        public int RMargin { get; set; }
        // If it's a peak
        public bool IsPeak { get; set; }
        // If it's a valley
        public bool IsValley { get; set; }





        // Constructor for PeakValley
        public PeakValley(int index, int lMargin, int rMargin, bool isPeak, bool isValley)
        {
            Index = index;
            LMargin = lMargin;
            RMargin = rMargin;
            IsPeak = isPeak;
            IsValley = isValley;


        }

        // Override ToString() 
        public override string ToString()
        {
            return $"Index: {Index}, LMargin: {LMargin}, RMargin: {RMargin}, Peak: {IsPeak}, Valley: {IsValley}";
        }
    }

}
