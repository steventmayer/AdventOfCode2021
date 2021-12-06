using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public class Day2 : IDayCommand
    {
        /// <summary>
        /// forward X increases the horizontal position by X units.
        /// down X increases the depth by X units.
        /// up X decreases the depth by X units.
        /// Your horizontal position and depth both start at 0.
        /// Calculate the horizontal position and depth you would have after following the planned course. 
        /// What do you get if you multiply your final horizontal position by your final depth?
        /// </summary>
        public async Task ExecutePart1Async(CancellationToken cancellationToken)
        {
            var inputFile = await File.ReadAllLinesAsync(".\\Day2\\input.txt", cancellationToken);
            var position = CalculatePositionMultiplied(inputFile);
            Console.WriteLine($"Final horizontal * depth is {position}");
        }

        /// <summary>
        /// down X increases your aim by X units.
        /// up X decreases your aim by X units.
        /// forward X does two things:
        /// It increases your horizontal position by X units.
        /// It increases your depth by your aim multiplied by X.
        /// What do you get if you multiply your final horizontal position by your final depth?
        /// </summary>
        public async Task ExecutePart2Async(CancellationToken cancellationToken)
        {
            var inputFile = await File.ReadAllLinesAsync(".\\Day2\\input.txt", cancellationToken);
            var position = CalculatePositionMultipliedPart2(inputFile);
            Console.WriteLine($"Final horizontal * depth is {position}");
        }

        public int CalculatePositionMultiplied(string[] instructions)
        {
            var position = CalculatePosition(instructions);
            Console.WriteLine($"Horizontal is {position.horizontal} and Depth is {position.depth}");
            return position.horizontal * position.depth;
        }

        public (int horizontal, int depth) CalculatePosition(string[] instructions)
        {
            int startingHorizontal = 0;
            int startingDepth = 0;

            foreach (var instruction in instructions)
            {
                var splitInstruction = instruction.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (splitInstruction.Length != 2)
                {
                    throw new Exception($"Invalid input: {instruction}");
                }

                var validNumber = int.TryParse(splitInstruction[1], out var step);
                if (!validNumber)
                {
                    throw new Exception($"Invalid input: {instruction}");
                }

                switch (splitInstruction[0].ToLower())
                {
                    case "forward":
                        startingHorizontal += step;
                        break;
                    case "down":
                        startingDepth += step;
                        break;
                    case "up":
                        startingDepth -= step;
                        break;
                    default:
                        throw new Exception($"Invalid input: {instruction}");
                }
            }

            return (startingHorizontal, startingDepth);
        }

        public int CalculatePositionMultipliedPart2(string[] instructions)
        {
            var position = CalculatePositionPart2(instructions);
            Console.WriteLine($"Horizontal is {position.horizontal}, Depth is {position.depth}, Aim is {position.aim}");
            return position.horizontal * position.depth;
        }

        public (int horizontal, int depth, int aim) CalculatePositionPart2(string[] instructions)
        {
            int startingHorizontal = 0;
            int startingDepth = 0;
            int aim = 0;

            foreach (var instruction in instructions)
            {
                var splitInstruction = instruction.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (splitInstruction.Length != 2)
                {
                    throw new Exception($"Invalid input: {instruction}");
                }

                var validNumber = int.TryParse(splitInstruction[1], out var step);
                if (!validNumber)
                {
                    throw new Exception($"Invalid input: {instruction}");
                }

                switch (splitInstruction[0].ToLower())
                {
                    case "forward":
                        startingHorizontal += step;
                        startingDepth += (aim * step);
                        break;
                    case "down":
                        aim += step;
                        break;
                    case "up":
                        aim -= step;
                        break;
                    default:
                        throw new Exception($"Invalid input: {instruction}");
                }
            }

            return (startingHorizontal, startingDepth, aim);
        }
    }
}
