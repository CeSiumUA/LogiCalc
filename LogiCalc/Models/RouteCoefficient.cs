using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiCalc.Models
{
    public record RouteCoefficient
    {
        public double Minimum { get; set; } = 0;
        public double Maximum { get; set; } = 0;
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
    }
}
