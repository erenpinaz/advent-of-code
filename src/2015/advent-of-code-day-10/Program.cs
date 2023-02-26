using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace advent_of_code_day_10
{
    internal class Program
    {
        private static string _input = "3113322113";

        private static void Main(string[] args)
        {
            for (var i = 1; i <= 40; i++)
            {
                _input = SolvePuzzle(_input);
                Console.WriteLine(i + "-) " + _input.Length);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Solves the puzzle input
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Length of the output</returns>
        private static string SolvePuzzle(string input)
        {
            // Group digits with adjacent repeats
            var matches = Regex.Matches(input, @"(\d)\1*");

            // Build output from occurrence + distinct value of the matching group
            return string.Concat(matches.Cast<Capture>().Select(m => m.Value.Length + m.Value.Substring(0, 1)));
        }
    }
}