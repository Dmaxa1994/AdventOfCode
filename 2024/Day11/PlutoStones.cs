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
            var stonesQueue = new Queue<string>(_puzzleData.Split(" "));

            for (var i = 0; i < blinks; i++)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"Processing blink {i + 1}/{blinks}");
                Console.WriteLine($"Processing {stonesQueue.Count} stones");

                var currentCount = stonesQueue.Count;

                // Process each stone in the current level
                for (var j = 0; j < currentCount; j++)
                {
                    var stone = stonesQueue.Dequeue();

                    if (stone == "0")
                    {
                        stonesQueue.Enqueue("1");
                        continue;
                    }

                    if (stone.Length % 2 == 0)
                    {
                        var stoneLength = (int)Math.Ceiling(stone.Length / 2.0);
                        var newStoneLeft = stone.Substring(0, stoneLength);
                        var newStoneRight = stone.Substring(stoneLength);
                        newStoneRight = int.Parse(newStoneRight).ToString();
                        stonesQueue.Enqueue(newStoneLeft);
                        stonesQueue.Enqueue(newStoneRight);
                        continue;
                    }

                    var newStone = (long.Parse(stone) * 2024).ToString();
                    stonesQueue.Enqueue(newStone);
                }
            }

            return stonesQueue.Count;
        }

        public long CountStonesOld(int blinks)
        {
            var stones = new List<string>(_puzzleData.Split(" "));
            var newStones = new List<string>();

            for (var i = 0; i < blinks; i++)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"Processing blink {i + 1}/{blinks}");
                Console.WriteLine($"Processing {stones.Count} stones");

                newStones.Clear();

                foreach (var stone in stones)
                {
                    if (stone == "0")
                    {
                        newStones.Add("1");
                        continue;
                    }

                    if (stone.Length % 2 == 0)
                    {
                        var stoneLength = (int)Math.Ceiling(stone.Length / 2.0);
                        var newStoneLeft = stone.Substring(0, stoneLength);
                        var newStoneRight = stone.Substring(stoneLength);
                        newStoneRight = int.Parse(newStoneRight).ToString();
                        newStones.Add(newStoneLeft);
                        newStones.Add(newStoneRight);
                        continue;
                    }

                    var newStone = (long.Parse(stone) * 2024).ToString();
                    newStones.Add(newStone);
                }

                // Swap stones with newStones without recreating
                var temp = stones;
                stones = newStones;
                newStones = temp;
            }

            return stones.Count;
        }



        public long Part2()
        {
            return CountStones(75);
        }

    }
}
