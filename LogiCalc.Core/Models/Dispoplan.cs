using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogiCalc.Core.Models
{
    public class Dispoplan
    {
        public List<RouteCoefficient> Routes { get; set; } = new List<RouteCoefficient>();
        public DateTime ActualBy { get; set; } = DateTime.Now;
        public void FillPlan(string rawText)
        {
            this.Routes.Clear();
            rawText = rawText.Replace("  ", " ");
            var matches = Regex.Matches(rawText, "Region ([A-Za-z]{1}[0-9]{1}) - ([A-Za-z]{1}[0-9]{1}) ([0-9]{1},[0-9]{2})-([0-9]{1},[0-9]{2})").ToList();
            foreach (var route in matches)
            {
                this.Routes.Add(new RouteCoefficient(route));
            }
        }
        public static Dispoplan CreateDispoplan(string rawText)
        {
            Dispoplan dispoplan = new Dispoplan();
            dispoplan.FillPlan(rawText);
            return dispoplan;
        }
    }
}
