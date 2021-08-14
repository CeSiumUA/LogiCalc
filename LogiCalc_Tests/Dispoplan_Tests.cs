using LogiCalc.Core.Models;
using Xunit;

namespace LogiCalc_Tests
{
    public class Dispoplan_Tests
    {
        [Theory]
        [InlineData("Region A1 - A2  1,00-1,10 \r\nRegion A1 - A3  1,00-1,10", 2)]
        public void Dispoplan_ReturnsValidPlan(string rawText, double expectedCount)
        {
            Dispoplan dispoplan = new Dispoplan();
            dispoplan.FillPlan(rawText);
            Assert.Equal(expectedCount, dispoplan.Routes.Count);
            Assert.Equal("A1", dispoplan.Routes[0].From);
            Assert.Equal("A2", dispoplan.Routes[0].To);
            Assert.Equal("A1", dispoplan.Routes[1].From);
            Assert.Equal("A3", dispoplan.Routes[1].To);
            Assert.Equal(1.00, dispoplan.Routes[0].Minimum);
            Assert.Equal(1.10, dispoplan.Routes[0].Maximum);
            Assert.Equal(1.00, dispoplan.Routes[1].Minimum);
            Assert.Equal(1.10, dispoplan.Routes[1].Maximum);
        }
    }
}