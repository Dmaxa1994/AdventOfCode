using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode._2015.Day05
{
    public class ListChecking(string puzzlePath)
    {
        private readonly string[] _puzzleData = File.ReadAllLines(puzzlePath);

        public int Part1()
        {
            var niceStrings = 0;
            foreach (var line in _puzzleData)
            {
                var vowels = Regex.Matches(line, @"(?=(a|e|i|o|u)){3}");
                var doubleLetters = Regex.Matches(line, @"(?=((\w)\2))");
                var forbiddenCharacters = Regex.Matches(line, @"(ab|cd|pq|xy)");
                if(vowels.Count >= 3 && doubleLetters.Any() && forbiddenCharacters.Count == 0)
                    niceStrings++;
            }

            return niceStrings;
        }
        
        public int Part2()
        {
            var niceStrings = 0;
            foreach (var line in _puzzleData)
            {
                var doubleDouble = Regex.Matches(line, @"(\w{2})\1");
                var separatedDouble = Regex.Matches(line, @"([a-z]).([a-z])\1");
                if(doubleDouble.Any() && separatedDouble.Any())
                    niceStrings++;
            }

            return niceStrings;
        }

    }
}
