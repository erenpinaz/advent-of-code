using System;
using System.Linq;

namespace advent_of_code_day_10
{
    internal class Program
    {
        private const string Input = "3113322113";

        private static void Main(string[] args)
        {
            Console.WriteLine(SolvePuzzle(Input, 40));
            Console.ReadLine();
        }

        /// <summary>
        /// Solves the puzzle input
        /// </summary>
        /// <param name="input"></param>
        /// <param name="count"></param>
        /// <returns>Length of the output</returns>
        private static int SolvePuzzle(string input, int count)
        {
            var output = string.Empty;

            for (var t = 0; t < count; t++)
            {
                var digits = output != string.Empty ? output.Select(d => int.Parse(d.ToString())).ToList() : input.Select(d => int.Parse(d.ToString())).ToList();

                output = string.Empty;

                int occurrence;
                for (var i = 0; i < digits.Count(); i += occurrence)
                {
                    var currentDigit = digits[i];
                    occurrence = 0;

                    var j = i;
                    do
                    {
                        occurrence++;
                        j++;
                    } while (digits.ElementAtOrDefault(j) != 0 && currentDigit == digits[j]);

                    output += occurrence.ToString() + currentDigit.ToString();
                }

                Console.WriteLine(output);
            }

            return output.Length;
        }
    }
}