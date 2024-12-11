using System.Data;
using System.Numerics;
using System.Text;

namespace AdventOfCode._2024.Day08
{
    public class AntiNodes
    {
        private readonly string[] _puzzleData = File.ReadAllLines(@"2024\day08\puzzleData.txt");
        //private readonly string[] _puzzleData = File.ReadAllLines(@"2024\day08\sample.txt");

        public long Part1()
        {
            var antiNodes = new HashSet<Vector2>();
            var nodes = new Dictionary<char, List<(int x, int y)>>();

            var x = 0;
            foreach (var line in _puzzleData)
            {
                var y = 0;
                foreach (var c in line)
                {
                    if (c == '.' || c == '#')
                    {
                        y++;
                        continue;
                    }

                    if (!nodes.ContainsKey(c))
                    {
                        nodes.Add(c, []);
                    }

                    nodes[c].Add((x, y));

                    y++;
                }

                x++;
            }

            var rowCount = _puzzleData.Length;
            var columnCount = _puzzleData[0].Length;

            foreach (var kvp in nodes)
            {
                for (var i = 0; i < kvp.Value.Count; i++)
                {
                    for (var j = i + 1; j < kvp.Value.Count; j++)
                    {
                        var node1 = kvp.Value[i];
                        var node2 = kvp.Value[j];

                        var node1Vector = new Vector2(node1.x, node1.y);
                        var node2Vector = new Vector2(node2.x, node2.y);

                        var vector = node1Vector - node2Vector;

                        var antiNode1 = node1Vector + vector;
                        var antiNode2 = node2Vector - vector;

                        if(antiNode1.X > -1 && antiNode1.X < rowCount &&
                           antiNode1.Y > -1 && antiNode1.Y < columnCount)
                            antiNodes.Add(antiNode1);

                        if(antiNode2.X > -1 && antiNode2.X < rowCount &&
                           antiNode2.Y > -1 && antiNode2.Y < columnCount)
                            antiNodes.Add(antiNode2);
                    }
                }
            }

            return antiNodes.Count;

        }

        public long Part2()
        {
            var antiNodes = new HashSet<(int x, int y)>();
            var nodes = new Dictionary<char, List<(int x, int y)>>();

            var x = 0;
            foreach (var line in _puzzleData)
            {
                var y = 0;
                foreach (var c in line)
                {
                    if (c == '.' || c == '#')
                    {
                        y++;
                        continue;
                    }

                    if (!nodes.ContainsKey(c))
                    {
                        nodes.Add(c, []);
                    }

                    nodes[c].Add((x, y));

                    y++;
                }

                x++;
            }

            var rowCount = _puzzleData.Length;
            var columnCount = _puzzleData[0].Length;

            foreach (var kvp in nodes)
            {
                for (var i = 0; i < kvp.Value.Count; i++)
                {
                    for (var j = i + 1; j < kvp.Value.Count; j++)
                    {
                        var node1 = kvp.Value[i];
                        var node2 = kvp.Value[j];

                        for (var y3 = 0; y3 < columnCount; y3++)
                        {
                            for (var x3 = 0; x3 < rowCount; x3++)
                            {
                                if (node1.x * (node2.y - y3) + node2.x * (y3 - node1.y) + x3 * (node1.y - node2.y) == 0)
                                {
                                    antiNodes.Add((x3, y3));
                                }
                            }
                        }
                    }
                }
            }

            return antiNodes.Count;
        }

    }
}
