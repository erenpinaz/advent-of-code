using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent_of_code_day_9
{
    /// <summary>
    /// Route class
    /// </summary>
    internal class Route
    {
        public string From { get; set; }

        public string To { get; set; }

        public int Distance { get; set; }
    }

    internal class Program
    {
        // Route list
        private static List<Route> _routes;

        private static void Main(string[] args)
        {
            Console.WriteLine(SolvePuzzle(ReadInput("input.txt")));
            Console.ReadLine();
        }

        /// <summary>
        /// Solves the puzzle input
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Distance of the shortest route</returns>
        private static string SolvePuzzle(IEnumerable<string> input)
        {
            // Populate route list from the input file
            _routes = input.Select(routeInput => new Route()
            {
                From = routeInput.Split(' ')[0],
                To = routeInput.Split(' ')[2],
                Distance = int.Parse(routeInput.Split('=')[1])
            }).ToList();

            // Extract locations from the routes
            // (Both from & to + No Duplicates)
            var locations = new HashSet<string>();
            _routes.ForEach(r =>
            {
                locations.Add(r.From);
                locations.Add(r.To);
            });

            // Create a list to store distance values for all possible routes
            var distances = new List<int>();

            // Generate all possible routes that Santa can choose
            var permutations = GeneratePermutations(locations.ToList()).ToList();
            permutations.ForEach(r =>
            {
                var route = string.Empty;
                r.ForEach(l =>
                {
                    route += l;
                    if (l != r.Last())
                    {
                        route += " -> ";
                    }
                });

                var distance = CalculateDistance(route);
                distances.Add(distance);
            });

            // Return the minimum and maximum values from the list
            return "Min: " + distances.Min() + ", Max: " + distances.Max();
        }

        /// <summary>
        /// Calculates the total distance of the given route
        /// </summary>
        /// <param name="route"></param>
        /// <returns>Total distance of the given route</returns>
        private static int CalculateDistance(string route)
        {
            var totalDistance = 0;
            var locations = route.Split(new string[] {" -> "}, StringSplitOptions.None);
            for (var i = 0; i < locations.Length - 1; i++)
            {
                totalDistance += _routes.First(r =>
                    (r.From == locations[i] && r.To == locations[i + 1]) ||
                    (r.To == locations[i] && r.From == locations[i + 1])).Distance;
            }

            return totalDistance;
        }

        /// <summary>
        /// Creates a list of all possible permutations
        /// of the items
        /// </summary>
        /// <param name="items"></param>
        /// <returns>Permutations list</returns>
        public static List<List<string>> GeneratePermutations(List<string> items)
        {
            if (items.Count == 1)
                return new List<List<string>>() {items};

            return
                items.Select(
                    i =>
                        GeneratePermutations(items.Where(x => !x.Equals(i)).ToList())
                            .Select(perm => (new List<string> {i}).Concat(perm).ToList())
                            .ToList()).SelectMany(x => x).ToList();
        }

        /// <summary>
        /// Reads the puzzle input from the file
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Each line of a given text file</returns>
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