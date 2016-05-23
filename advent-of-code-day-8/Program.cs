using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace advent_of_code_day_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SolvePuzzle(ReadInput("input.txt")));
            Console.ReadLine();
        }

        /// <summary>
        /// Solves the puzzle input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static int SolvePuzzle(IEnumerable<string> input)
        {
            int escapedCount = 0, unescapedCount = 0;

            foreach (var line in input)
            {
                escapedCount += line.Length;
                unescapedCount += Regex.Unescape(line.Substring(1, line.Length - 2)).Length;
            }

            return escapedCount - unescapedCount;
        }

        /// <summary>
        /// Reads the puzzle input from the file
        /// </summary>
        /// <param name="path"></param>
        /// <returns>List of lines of a given text file</returns>
        private static IEnumerable<string> ReadInput(string path)
        {
            using (var reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
