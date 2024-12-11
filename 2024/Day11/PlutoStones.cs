using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.Text;

namespace AdventOfCode._2024.Day11
{
    public class PlutoStones
    {
        private readonly string _puzzleData = File.ReadAllText(@"2024\day11\puzzleData.txt");
        //private readonly string _puzzleData = File.ReadAllText(@"2024\day11\sample.txt");

        public long Part1()
        {
            return CountStones(25);
        }

        public long CountStones(int blinks)
        {
            var stoneCounts = _puzzleData
                .Split(" ")
                .Select(long.Parse)
                .GroupBy(stone => stone)
                .ToDictionary(group => group.Key, group => (long)group.Count());

            for (var i = 0; i < blinks; i++)
            {
                var nextStoneCounts = new Dictionary<long, long>();

                foreach (var (stone, count) in stoneCounts)
                {
                    if (stone == 0)
                    {
                        AddStone(nextStoneCounts, 1, count);
                    }
                    else
                    {
                        var length = (int)Math.Floor(Math.Log10(stone)) + 1;

                        if (length % 2 == 0)
                        {
                            var splitPoint = length / 2;
                            var divisor = (long)Math.Pow(10, splitPoint);
                            var left = stone / divisor;
                            var right = stone % divisor;

                            AddStone(nextStoneCounts, left, count);
                            AddStone(nextStoneCounts, right, count);
                        }
                        else
                        {
                            var newStone = stone * 2024;
                            AddStone(nextStoneCounts, newStone, count);
                        }
                    }
                }

                stoneCounts = nextStoneCounts;
            }

            return stoneCounts.Values.Sum();
        }

        private static void AddStone(Dictionary<long, long> stoneCounts, long stone, long count)
        {
            if (stoneCounts.ContainsKey(stone))
                stoneCounts[stone] += count;
            else
                stoneCounts[stone] = count;
        }

        public long Part2()
        {
            return CountStones(75);
        }

    }
}
