using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace advent_of_code_day_11
{
    internal class Program
    {
        private static string _input = "hxbxwxba";
        private static int _step = _input.Length - 1;

        private static void Main(string[] args)
        {
            _input = SolvePuzzle(_input);
            Console.WriteLine(_input);

            _input = SolvePuzzle(_input);
            Console.WriteLine(_input);

            Console.ReadLine();
        }

        /// <summary>
        /// Solves the puzzle input
        /// </summary>
        /// <param name="input"></param>
        /// <returns>The next password</returns>
        private static string SolvePuzzle(string input)
        {
            var password = input.ToCharArray();

            while (true)
            {
                password = Increment(password, _step);

                if (HasStraightSequence(password) && !HasBannedLetters(password) &&
                    HasTwoNonOverlapping(password))
                {
                    return new string(password);
                }
            }
        }

        /// <summary>
        /// Checks if password has repeating letters
        /// </summary>
        /// <param name="password"></param>
        /// <returns>True or false</returns>
        private static bool HasTwoNonOverlapping(char[] password)
        {
            return Regex.IsMatch(new string(password), @"(\w)\1.*(\w)\2");
        }

        /// <summary>
        /// Checks if password has increasing straight sequence
        /// </summary>
        /// <param name="password"></param>
        /// <returns>True or false</returns>
        private static bool HasStraightSequence(char[] password)
        {
            var isValid = false;
            for (var i = 0; i < password.Count() - 2; i++)
            {
                if (password[i + 1] == password[i] + 1 && password[i + 2] == password[i + 1] + 1)
                {
                    isValid = true;
                }
            }

            return isValid;
        }

        /// <summary>
        /// Checks if password has banned letters
        /// </summary>
        /// <param name="password"></param>
        /// <returns>True or false</returns>
        private static bool HasBannedLetters(char[] password)
        {
            return password.Contains('l') || password.Contains('i') || password.Contains('o');
        }

        /// <summary>
        /// Increments the password characters
        /// </summary>
        /// <param name="password"></param>
        /// <param name="step"></param>
        /// <returns>Incremented password</returns>
        private static char[] Increment(char[] password, int step)
        {
            if (password[step] == 'z')
            {
                password[step] = 'a';

                _step = _step - 1;
                password = Increment(password, _step);
            }
            else
            {
                _step = password.Length - 1;
                password[step]++;
            }

            return password;
        }
    }
}