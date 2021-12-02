using Xunit;

namespace AdventOfCode2021.Tests
{
    public class Day1Tests
    {
        [Fact]
        public void Part1_NoInput_ReturnZero()
        {
            var day = new Day1();
            var numberOfDepthIncrease = day.CalculateNumberOfIncreasingDepth(Array.Empty<int>());

            Assert.Equal(0, numberOfDepthIncrease);
        }

        [Fact]
        public void Part1_AllDecreasing_ReturnsZero()
        {
            var day = new Day1();
            var depths = new int[] { 200, 199, 197 };
            var numberOfDepthIncrease = day.CalculateNumberOfIncreasingDepth(depths);

            Assert.Equal(0, numberOfDepthIncrease);
        }

        [Fact]
        public void Part1_EndsWithIncrease_ReturnsCorrectNumberWithinBounds() // Test Bounds.
        {
            var day = new Day1();
            var depths = new int[] { 200, 199, 197, 200 };
            var numberOfDepthIncrease = day.CalculateNumberOfIncreasingDepth(depths);

            Assert.Equal(1, numberOfDepthIncrease);
        }

        [Fact]
        public void Part1_DepthRemainsSame_ReturnsZero()
        {
            var day = new Day1();
            var depths = new int[] { 200, 200, 200, 200 };
            var numberOfDepthIncrease = day.CalculateNumberOfIncreasingDepth(depths);

            Assert.Equal(0, numberOfDepthIncrease);
        }

        [Fact]
        public void Part1_MultipleIncreases_ReturnsNumberOfIncreases()
        {
            var day = new Day1();
            var depths = new int[] { 197, 198, 200, 197 };
            var numberOfDepthIncrease = day.CalculateNumberOfIncreasingDepth(depths);

            Assert.Equal(2, numberOfDepthIncrease);
        }

        [Fact]
        public void Part2_NoInput_ReturnZero()
        {
            var day = new Day1();
            var numberOfDepthIncrease = day.CalculateNumberOfIncreasingDepthWindows(Array.Empty<int>(), 3);

            Assert.Equal(0, numberOfDepthIncrease);
        }

        [Fact]
        public void Part2_InputIsSmallerThanWindow_ReturnsZero()
        {
            var day = new Day1();
            var depths = new int[] { 200, 199, 197 };
            var numberOfDepthIncrease = day.CalculateNumberOfIncreasingDepthWindows(depths, 5);

            Assert.Equal(0, numberOfDepthIncrease);
        }

        [Fact]
        public void Part2_EndsWithIncrease_ReturnsCorrectNumberWithinBounds() // Test Bounds.
        {
            var day = new Day1();
            var depths = new int[] { 200, 199, 197, 208 };
            var numberOfDepthIncrease = day.CalculateNumberOfIncreasingDepthWindows(depths, 3);

            Assert.Equal(1, numberOfDepthIncrease);
        }

        [Fact]
        public void Part2_DepthWindowRemainsSame_ReturnsZero()
        {
            var day = new Day1();
            var depths = new int[] { 200, 198, 199, 200 };
            var numberOfDepthIncrease = day.CalculateNumberOfIncreasingDepthWindows(depths, 3);

            Assert.Equal(0, numberOfDepthIncrease);
        }

        [Fact]
        public void Part2_MultipleIncreases_ReturnsNumberOfIncreases()
        {
            var day = new Day1();
            var depths = new int[] { 197, 198, 200, 198, 199, 201 }; // returns 1 for each set [198,200,198], [200,198,199], [198,199, 201]
            var numberOfDepthIncrease = day.CalculateNumberOfIncreasingDepthWindows(depths, 3);

            Assert.Equal(3, numberOfDepthIncrease);
        }
    }
}
