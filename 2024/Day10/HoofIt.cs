using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.Text;

namespace AdventOfCode._2024.Day10
{
    public class HoofIt
    {
        private readonly string[] _puzzleData = File.ReadAllLines(@"2024\day10\puzzleData.txt");
        //private readonly string[] _puzzleData = File.ReadAllLines(@"2024\day10\sample.txt");
        // part 1 I used a bfs search algorithm
        // part 2 was an accident while I was figuring out part 1
        public long Part1()
        {
            var trailHeads = FindTrailHeads();
            var completePaths = FindTrailHeadScore(trailHeads);
            return completePaths;
        }

        private int FindTrailHeadScore(List<Vector2> trailHeads)
        {
            var validPaths = 0;
            foreach (var startingPos in trailHeads)
            {
                var visited = new HashSet<Vector2>();
                var queue = new Queue<Vector2>();
                queue.Enqueue(startingPos);
                while (queue.Count > 0)
                {
                    var position = queue.Dequeue();
                    if (!visited.Contains(position))
                    {
                        visited.Add(position);
                        var height = _puzzleData[(int)position.X][(int)position.Y];
                        if (height == '9')
                        {
                            validPaths++;
                            continue;
                        }
                        var validNeighbours = new List<Vector2>();
                        var option1 = position with {X = position.X - 1};
                        var option2 = position with {X = position.X + 1};
                        var option3 = position with {Y = position.Y - 1};
                        var option4 = position with {Y = position.Y + 1};

                        if (IsOptionValid(option1, height))
                            validNeighbours.Add(option1);

                        if (IsOptionValid(option2, height))
                            validNeighbours.Add(option2);

                        if (IsOptionValid(option3, height))
                            validNeighbours.Add(option3);

                        if (IsOptionValid(option4, height))
                            validNeighbours.Add(option4);

                        foreach (var n in validNeighbours)
                        {
                            queue.Enqueue(n);
                        }
                    }
                }
            }

            return validPaths;
        }

        private int FindPaths(List<Vector2> branches)
        {
            var validPaths = 0;
            var i = 0;
            for(i = 0; i < branches.Count; i++)
            {
                var position = branches[i];
                var height = _puzzleData[(int)position.X][(int)position.Y];
                if (height == '9')
                {
                    validPaths++;
                    continue;
                }
                var option1 = position with {X = position.X - 1};
                var option2 = position with {X = position.X + 1};
                var option3 = position with {Y = position.Y-1};
                var option4 = position with {Y = position.Y+1};

                if (IsOptionValid(option1, height))
                {
                    branches.Add(option1);
                }

                if (IsOptionValid(option2, height))
                {
                    branches.Add(option2);
                }

                if (IsOptionValid(option3, height))
                {
                    branches.Add(option3);
                }

                if (IsOptionValid(option4, height))
                {
                    branches.Add(option4);
                }
            }

            return validPaths;
        }

        bool IsOptionValid(Vector2 option, char height)
        {
            var lineLength = _puzzleData[0].Length;
            var maxLines = _puzzleData.Length;
            if (option.X <= -1 || option.X >= maxLines ||
                option.Y <= -1 || option.Y >= lineLength)
                return false;

            var newHeight = _puzzleData[(int)option.X][(int)option.Y];
            if (int.Parse($"{newHeight}") != int.Parse($"{height}") + 1)
                return false;

            return true;
        }

        public List<Vector2> FindTrailHeads()
        {
            var trailHeads = new List<Vector2>();
            for (var x = 0; x < _puzzleData.Length; x++)
            {
                for (var y = 0; y < _puzzleData[x].Length; y++)
                {
                    if(_puzzleData[x][y] == '0')
                        trailHeads.Add(new Vector2(x, y));
                }
            }

            return trailHeads;
        }

        public long Part2()
        {
            var trailHeads = FindTrailHeads();
            var completePaths = FindPaths(trailHeads);
            return completePaths;
        }

    }
}
