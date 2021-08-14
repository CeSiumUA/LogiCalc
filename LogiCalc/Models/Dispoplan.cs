using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiCalc.Models
{
    public class Dispoplan
    {
        public List<RouteCoefficient> Routes { get; set; } = new List<RouteCoefficient>();
        public DateTime ActualBy { get; set; } = DateTime.Now;
        public void FillPlan(string rawText)
        {

        }
        public static Dispoplan CreateDispoplan(string rawText)
        {
            Dispoplan dispoplan = new Dispoplan();
            dispoplan.FillPlan(rawText);
            return dispoplan;
        }
    }
}
