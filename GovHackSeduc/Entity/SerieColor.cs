using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GovHackSeduc.Entity
{
    public class SerieColor
    {
        public string _backgroundColor;
        public string _borderColor;

        public SerieColor(string BackgroundColor, string BorderColor)
        {
            _backgroundColor = BackgroundColor;
            _borderColor = BorderColor;
        }

        public string BackgroundColor { get { return _backgroundColor;  } set { _backgroundColor = value;  } }
        public string BorderColor { get { return _borderColor; } set { _borderColor = value; } }
    }
}