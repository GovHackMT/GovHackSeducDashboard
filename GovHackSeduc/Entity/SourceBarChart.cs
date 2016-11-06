using System.Collections.Generic;

namespace GovHackSeduc.Entity
{
    public class SourceBarChart
    {
        public SourceBarChart()
        {
            XValues = new List<string>();
            YValues = new List<decimal>();
            BackGroundColor = new List<string>();
            BorderColor = new List<string>();
        }

        public List<string> XValues { get; set; }
        public List<decimal> YValues { get; set; }
        public List<string> BackGroundColor { get; set; }
        public List<string> BorderColor { get; set; }
    }
}