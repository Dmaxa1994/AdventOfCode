using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2024.Day01
{
    public class HistorianHysteria
    {
        private readonly string[] _puzzleData = File.ReadAllLines(@"2024\day01\PuzzleData.txt");
        private readonly List<int> _firstColumn = new List<int>();
        private readonly List<int> _secondColumn = new List<int>();

        public HistorianHysteria()
        {
            foreach (var line in _puzzleData)
            {
                var lineParts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                _firstColumn.Add(int.Parse(lineParts[0]));
                _secondColumn.Add(int.Parse(lineParts[1]));
            }

            _firstColumn.Sort();
            _secondColumn.Sort();
        }


        public int Part1()
        {
            int total = 0;
            for (int i = 0; i < _firstColumn.Count; i++)
            {
                total += Math.Abs(_firstColumn[i] - _secondColumn[i]);
            }

            return total;
        }

        public int Part2()
        {
            var frequencyMap = new Dictionary<int, int>();

            foreach (var num in _secondColumn)
            {
                if (!frequencyMap.TryAdd(num, 1))
                {
                    frequencyMap[num]++;
                }
            }
            
            var total = 0;
            foreach (var i in _firstColumn)
            {
                if (frequencyMap.TryGetValue(i, out var count))
                {
                    total += i * count;
                }
            }

            return total;
        }
    }
}
