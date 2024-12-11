using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;

namespace AdventOfCode._2024.Day05
{
    public class PrintQueue
    {
        private readonly string[] _puzzleDataPageOrder = File.ReadAllLines(@"2024\day05\PuzzleData-PageOrder.txt");
        private readonly string[] _puzzleDataUpdates = File.ReadAllLines(@"2024\day05\PuzzleData-Updates.txt");

        public int Part1()
        {
            var total = 0;

            foreach (var update in _puzzleDataUpdates)
            {
                var isUpdateValid = true;
                var pages = update.Split(",").ToList();
                var rules = new List<string>();
                foreach (var page in pages)
                {
                    rules.AddRange(_puzzleDataPageOrder.Where(x => x.Contains(page)).Distinct().ToList());
                }

                foreach (var rule in rules)
                {
                    var pageOrder = rule.Split("|");
                    var first = pageOrder[0];
                    var second = pageOrder[1];

                    var firstIndex = pages.IndexOf(first);
                    var secondIndex = pages.IndexOf(second);

                    if (firstIndex == -1 || secondIndex == -1)
                        continue;

                    if (firstIndex < secondIndex)
                        continue;

                    isUpdateValid = false;
                    break;
                }

                if (isUpdateValid)
                {
                    var middlePoint = (int)MathF.Floor(pages.Count/ 2);
                    total += int.Parse(pages[middlePoint]);
                }
            }

            return total;
        }

       
        public int Part2()
        {
            var total = 0;
            foreach (var update in _puzzleDataUpdates)
            {
                var isUpdateValid = true;
                var pages = update.Split(",").ToList();
                var rules = new List<string>();
                foreach (var page in pages)
                {
                    rules.AddRange(_puzzleDataPageOrder.Where(x => x.Contains(page)).Distinct().ToList());
                }

                var validRules = new List<string>();
                foreach (var rule in rules)
                {
                    var pageOrder = rule.Split("|");
                    var first = pageOrder[0];
                    var second = pageOrder[1];

                    var firstIndex = pages.IndexOf(first);
                    var secondIndex = pages.IndexOf(second);

                    if (firstIndex == -1 || secondIndex == -1)
                        continue;

                    validRules.Add(rule);
                    if (firstIndex < secondIndex)
                        continue;

                    isUpdateValid = false;
                }

                if(isUpdateValid)
                    continue;

                validRules = validRules.Distinct().ToList();
                validRules.Sort();
                var valid = false;
                while (!valid)
                {
                    valid = true;
                    foreach (var rule in validRules)
                    {
                        var pageOrder = rule.Split("|");
                        var first = pageOrder[0];
                        var second = pageOrder[1];

                        var firstIndex = pages.IndexOf(first);
                        var secondIndex = pages.IndexOf(second);

                        if (firstIndex > secondIndex)
                        {
                            var firstHolder = pages[firstIndex];
                            var secondHolder = pages[secondIndex];
                            pages[firstIndex] = secondHolder;
                            pages[secondIndex] = firstHolder;
                            valid = false;
                        }
                    }
                }

                var middlePoint = (int)MathF.Floor(pages.Count/ 2);
                total += int.Parse(pages[middlePoint]);
            }

            return total;
        }
    }
}
