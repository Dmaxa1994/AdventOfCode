using System.Text;

namespace AdventOfCode._2024.Day06
{
    public class GuardGallivant
    {
        private readonly string[] _puzzleData = File.ReadAllLines(@"2024\day06\puzzleData.txt");
        //private readonly string[] _puzzleData = File.ReadAllLines(@"2024\day06\sample.txt");

        public enum GuardDir
        {
            Up,
            Right,
            Down,
            Left,
        }

        public int Part1()
        {
            var total = 0;
            var guardDir = GuardDir.Up;
            var guardPos = GetStartingPos();
            var uniquePositions = new HashSet<(int, int)>
            {
                guardPos.Value
            };

            while (true)
            {
                var adjustedCoordinates = GetNewPos(guardDir, guardPos.Value.x, guardPos.Value.y);

                try
                {
                    while (true)
                    {
                        if (_puzzleData[adjustedCoordinates.x][adjustedCoordinates.y] == '#')
                        {
                            guardDir++;
                            if ((int) guardDir == 4) guardDir = 0;
                            adjustedCoordinates = GetNewPos(guardDir, guardPos.Value.x, guardPos.Value.y);
                        }
                        else
                        {
                            break;
                        }
                    }

                    guardPos = GetNewPos(guardDir, guardPos.Value.x, guardPos.Value.y);
                    uniquePositions.Add(guardPos.Value);
                }
                catch
                {
                    break;
                }
                
            }

            return uniquePositions.Count;
        }

        (int x, int y)? GetStartingPos()
        {
            (int x, int y)? guardPos = null;

            for (var i = 0; i < _puzzleData.Length; i++)
            {
                for (var j = 0; j < _puzzleData[i].Length; j++)
                {
                    if (_puzzleData[i][j] == '^')
                    {
                        guardPos = (i, j);
                        break;
                    }
                }

                if (guardPos != null)
                    break;
            }

            return guardPos;
        }

        (int x, int y) GetNewPos(GuardDir guardDir, int x, int y)
        {
            switch (guardDir)
            {
                case GuardDir.Up:
                    x -= 1;
                    break;
                case GuardDir.Down:
                    x += 1;
                    break;
                case GuardDir.Left:
                    y -= 1;
                    break;
                case GuardDir.Right:
                    y += 1;
                    break;
            }

            return (x, y);
        }

        public int Part2()
        {
            var total = 0;
            var guardDir = GuardDir.Up;
            var guardPos = GetStartingPos();
            var uniquePositions = new HashSet<(int x, int y)>
            {
                guardPos.Value
            };

            while (true)
            {
                var adjustedCoordinates = GetNewPos(guardDir, guardPos.Value.x, guardPos.Value.y);

                try
                {
                    if (_puzzleData[adjustedCoordinates.x][adjustedCoordinates.y] == '#')
                    {
                        guardDir++;
                        if ((int)guardDir == 4) guardDir = 0;
                    }

                    guardPos = GetNewPos(guardDir, guardPos.Value.x, guardPos.Value.y);
                    uniquePositions.Add(guardPos.Value);
                }
                catch
                {
                    break;
                }
                
            }

            foreach (var pos in uniquePositions)
            {
                var puzzleData = _puzzleData.Clone() as string[];
                if (puzzleData[pos.x][pos.y] == '.')
                {
                    var sb = new StringBuilder(puzzleData[pos.x]);
                    sb[pos.y] = '#';
                    puzzleData[pos.x] = sb.ToString();
                    if (!CanGuardEscape(puzzleData))
                        total++;
                }
            }

            return total;
        }

        public bool CanGuardEscape(string[] puzzleData)
        {
            var guardDir = GuardDir.Up;
            var guardPos = GetStartingPos();
            var visited = new HashSet<((int, int), GuardDir)>
            {
                (guardPos.Value, guardDir)
            };

            while (true)
            {
                var adjustedCoordinates = GetNewPos(guardDir, guardPos.Value.x, guardPos.Value.y);

                if (adjustedCoordinates.x < 0 || adjustedCoordinates.x > puzzleData.Length - 1 ||
                    adjustedCoordinates.y < 0 || adjustedCoordinates.y > puzzleData[adjustedCoordinates.x].Length - 1)
                    return true;

                while (true)
                {
                    if (puzzleData[adjustedCoordinates.x][adjustedCoordinates.y] == '#')
                    {
                        guardDir++;
                        if ((int) guardDir == 4) guardDir = 0;
                        adjustedCoordinates = GetNewPos(guardDir, guardPos.Value.x, guardPos.Value.y);
                    }
                    else
                    {
                        break;
                    }
                }

                guardPos = GetNewPos(guardDir, guardPos.Value.x, guardPos.Value.y);
                if (!visited.Add((guardPos.Value, guardDir)))
                {
                    return false;
                }
            }
        }

    }
}
