using System.Text.RegularExpressions;

namespace AdventOfCode._2024.Day03
{
    public class MullItOver
    {
        private readonly string _puzzleData = File.ReadAllText(@"2024\day03\PuzzleData.txt");


        public int Part1()
        {
            var total = 0;
            var matches = Regex.Matches(_puzzleData, @"(mul\([0-9]*,[0-9]*\))");
            foreach (var match in matches)
            {
                var matchStr = match.ToString();
                var matchParts = matchStr.Split(",");
                var num1 = int.Parse(matchParts[0].Split("(")[1]);
                var num2 = int.Parse(matchParts[1].Split(")")[0]);
                total += num1 * num2;
            }

            return total;
        }


        public int Part2()
        {
            var total = 0;
            var matches = Regex.Matches(_puzzleData, @"(mul\([0-9]*,[0-9]*\))|(do\(\))|(don\'t\(\))");
            var process = true;
            foreach (var match in matches)
            {
                var matchStr = match.ToString();
                if(string.IsNullOrWhiteSpace(matchStr))
                    continue;

                if (matchStr == "do()")
                {
                    process = true;
                    continue;
                }

                if (matchStr == "don't()")
                {
                    process = false;
                    continue;
                }
                
                if (process)
                {
                    var matchParts = matchStr.Split(",");
                    var num1 = int.Parse(matchParts[0].Split("(")[1]);
                    var num2 = int.Parse(matchParts[1].Split(")")[0]);
                    total += num1 * num2;
                }
            }

            return total;
        }
    }
}
