namespace AdventOfCode2021
{
    public class Day1 : IDayCommand
    {
        /// <summary>
        /// The first order of business is to figure out how quickly the depth increases,
        /// just so you know what you're dealing with - 
        /// you never know if the keys will get carried into deeper water by an ocean current or a fish or something.
        /// To do this, count the number of times a depth measurement increases from the previous measurement. (There is no measurement before the first measurement.) In the example above, the changes are as follows:
        // 199 (N/A - no previous measurement)
        // 200 (increased)
        // 208 (increased)
        // 210 (increased)
        // 200 (decreased)
        // 207 (increased)
        // 240 (increased)
        // 269 (increased)
        // 260 (decreased)
        // 263 (increased)
        // In this example, there are 7 measurements that are larger than the previous measurement.
        /// </summary>
        public async Task ExecutePart1Async(CancellationToken cancellationToken)
        {
            var inputFile = await File.ReadAllLinesAsync(".\\Day1\\input.txt", cancellationToken);
            var depths = inputFile.Select(c => Convert.ToInt32(c)).ToArray();
            var numberOfIncreasingMeasurements = CalculateNumberOfIncreasingDepth(depths);

            Console.WriteLine($"There are {numberOfIncreasingMeasurements} measurements that are larger than the previous measurement.");
        }

        /// <summary>
        /// Considering every single measurement isn't as useful as you expected: there's just too much noise in the data.
        /// Instead, consider sums of a three-measurement sliding window
        /// 199  A      
        /// 200  A B    
        /// 208  A B C  
        /// 210    B C D
        /// 200  E C D
        /// 207  E F   D
        /// 240  E F G  
        /// 269    F G H
        /// 260      G H
        /// 263        H
        /// Start by comparing the first and second three-measurement windows. The measurements in the first window are marked A (199, 200, 208);
        /// their sum is 199 + 200 + 208 = 607. The second window is marked B (200, 208, 210); its sum is 618. 
        /// The sum of measurements in the second window is larger than the sum of the first, so this first comparison increased.
        /// Your goal now is to count the number of times the sum of measurements in this sliding window increases from the previous sum.
        /// So, compare A with B, then compare B with C, then C with D, and so on.
        /// Stop when there aren't enough measurements left to create a new three-measurement sum.
        /// </summary>
        public async Task ExecutePart2Async(CancellationToken cancellationToken)
        {
            var inputFile = await File.ReadAllLinesAsync(".\\Day1\\input.txt", cancellationToken);
            var depths = inputFile.Select(c => Convert.ToInt32(c)).ToArray();
            const int windowSize = 3;
            var numberOfIncreasingMeasurements = CalculateNumberOfIncreasingDepthWindows(depths, windowSize);

            Console.WriteLine($"There are {numberOfIncreasingMeasurements} measurements that are larger than the previous measurement.");
        }

        public int CalculateNumberOfIncreasingDepth(int[] depths)
        {
            if (depths.Length == 0)
            {
                return 0;
            }

            var numberOfIncreasingMeasurements = 0;
            var previousInput = depths[0];
            for (var i = 1; i < depths.Length; i++)
            {
                if (depths[i] > previousInput)
                {
                    numberOfIncreasingMeasurements++;
                    // previousInput = depths[i]; First Bug. Guessed 1496, wrong.
                }

                previousInput = depths[i];
                // first bug, did not set previous input to depths[i] on all.
            }

            return numberOfIncreasingMeasurements;
        }

        public int CalculateNumberOfIncreasingDepthWindows(int[] depths, int windowSize)
        {
            int[] measurementWindow = new int[windowSize];
            var numberOfIncreasingMeasurements = 0;

            // set initial window.
            if (depths.Length < windowSize)
            {
                return 0;
            }
            for (var i = 0; i < windowSize; i++)
            {
                measurementWindow[i] = depths[i];
            }

            var previousInput = measurementWindow.Sum();

            for (var i = 1; i < depths.Length - windowSize + 1; i++) // First bug. Had just windowSize, and we would miss last measurement.
            {
                measurementWindow[0] = depths[i];
                measurementWindow[1] = depths[i + 1];
                measurementWindow[2] = depths[i + 2];

                var newSum = measurementWindow.Sum();
                if (newSum > previousInput)
                {
                    numberOfIncreasingMeasurements++;
                }

                previousInput = newSum;
            }

            return numberOfIncreasingMeasurements;
        }
    }
}
