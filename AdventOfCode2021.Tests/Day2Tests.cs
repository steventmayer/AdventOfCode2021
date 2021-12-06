using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode2021.Tests
{
    public class Day2Tests
    {
        [Fact]
        public void CalculatePositionMultipled_TestCase_Returns150()
        {
            var day = new Day2();
            var instructions = new string[]
            {
                "forward 5",
                "down 5",
                "forward 8",
                "up 3",
                "down 8",
                "forward 2",
            };

            var result = day.CalculatePositionMultiplied(instructions);
            Assert.Equal(150, result);
        }

        [Fact]
        public void CalculatePositionMultipledPart2_TestCase_Returns900()
        {
            var day = new Day2();
            var instructions = new string[]
            {
                "forward 5",
                "down 5",
                "forward 8",
                "up 3",
                "down 8",
                "forward 2",
            };

            var result = day.CalculatePositionMultipliedPart2(instructions);
            Assert.Equal(900, result);
        }
    }
}
