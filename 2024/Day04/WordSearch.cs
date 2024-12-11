using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode._2024.Day04
{
    public class WordSearch
    {
        private readonly string[] _puzzleData = File.ReadAllLines(@"2024\day04\PuzzleData.txt");

        public int Part1()
        {
            var total = 0;
            foreach (var line in _puzzleData)
            {
                total += FindUsingRegex(line, "(XMAS)");
                total += FindUsingRegex(line, "(SAMX)");
            }

            for (int i = 3; i < _puzzleData.Length; i++)
            {
                var lines = new []
                {
                    _puzzleData[i - 3],
                    _puzzleData[i - 2],
                    _puzzleData[i - 1],
                    _puzzleData[i]
                };
                total += FindVertical(lines);
                total += FindDiagonalLeft(lines);
                total += FindDiagonalRight(lines);
            }
            return total;
        }

        public int FindUsingRegex(string line, string regex)
        {
            var macthes = Regex.Matches(line, regex);
            return macthes.Count;
        }

        public int FindVertical(string[] lines)
        {
            var targetWords = new[]
            {
                "XMAS",
                "SAMX"
            };
            var total = 0;
            for(int i = 0; i<lines[0].Length; i++)
            {
                var first = lines[0][i];
                var second = lines[1][i];
                var third = lines[2][i];
                var fourth = lines[3][i];

                if (targetWords.Contains($"{first}{second}{third}{fourth}"))
                    total++;
            }

            return total;
        }

        public int FindDiagonalRight(string[] lines)
        {
            var targetWords = new[]
            {
                "XMAS",
                "SAMX"
            };
            var total = 0;
            for (var i = 0; i < lines[0].Length - 3; i++)
            {
                var first = lines[0][i];
                var second = lines[1][i+1];
                var third = lines[2][i+2];
                var fourth = lines[3][i+3];

                if (targetWords.Contains($"{first}{second}{third}{fourth}"))
                    total++;
            }
            return total;
        }

        public int FindDiagonalLeft(string[] lines)
        {
            var targetWords = new[]
            {
                "XMAS",
                "SAMX"
            };
            var total = 0;
            for (var i = 3; i < lines[0].Length; i++)
            {
                var first = lines[0][i];
                var second = lines[1][i-1];
                var third = lines[2][i-2];
                var fourth = lines[3][i-3];

                if (targetWords.Contains($"{first}{second}{third}{fourth}"))
                    total++;
            }
            return total;
        }

        public int FindX(string[] lines)
        {
            var total = 0;
            var targetWords = new[]
            {
                "MAS",
                "SAM"
            };
            for (var i = 0; i < lines[0].Length - 2; i++)
            {
                var topLeft = lines[0][i];
                var center = lines[1][i + 1];
                var bottomRight = lines[2][i + 2];
                var topRight = lines[0][i + 2];
                var bottomLeft = lines[2][i];

                if (targetWords.Contains($"{topLeft}{center}{bottomRight}") &&
                    targetWords.Contains($"{topRight}{center}{bottomLeft}"))
                    total++;
            }

            return total;
        }

        public int Part2()
        {
            var total = 0;

            for (int i = 2; i < _puzzleData.Length; i++)
            {
                var lines = new []
                {
                    _puzzleData[i - 2],
                    _puzzleData[i - 1],
                    _puzzleData[i]
                };

                total += FindX(lines);
            }

            return total;
        }
    }
}
