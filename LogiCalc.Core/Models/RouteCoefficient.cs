using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogiCalc.Core.Models
{
    public class RouteCoefficient
    {
        public double Minimum { get; set; } = 0;
        public double Maximum { get; set; } = 0;
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public RouteCoefficient()
        {

        }
        public RouteCoefficient(Match text)
        {
            ParseMatch(text);
        }
        private void ParseMatch(Match regex)
        {
            this.From = regex.Groups[1].Value;
            this.To = regex.Groups[2].Value;
            this.Minimum = double.Parse(regex.Groups[3].Value.Replace(",", "."), CultureInfo.InvariantCulture);
            this.Maximum = double.Parse(regex.Groups[4].Value.Replace(",", "."), CultureInfo.InvariantCulture);
        }
    }
}
