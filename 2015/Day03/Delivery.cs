namespace AdventOfCode._2015.Day03
{
    public class Delivery(string puzzlePath)
    {
        private readonly string _puzzleData = File.ReadAllText(puzzlePath);

        public int Part1()
        {
            var houses = new HashSet<(int x, int y)>();
            var x = 0;
            var y = 0;
            houses.Add((x, y));

            foreach (var c in _puzzleData)
            {
                switch (c)
                {
                    case '>' :
                        x++;
                        break;
                    case '^' :
                        y--;
                        break;
                    case '<' :
                        x--;
                        break;
                    case 'v' :
                        y++;
                        break;
                }

                houses.Add((x, y));
            }

            return houses.Count;
        }

        public int Part2()
        {
            var santaCoordinates = (0, 0);
            var roboCoordinates = (0, 0);

            var houses = new HashSet<(int x, int y)>();
            houses.Add((0, 0));
            for (var i = 0; i < _puzzleData.Length; i++)
            {
                var c = _puzzleData[i];
                if (i % 2 == 1)
                {
                    santaCoordinates = IncrementCoordinates(c, santaCoordinates);
                    houses.Add(santaCoordinates);
                }
                else
                {
                    roboCoordinates = IncrementCoordinates(c, roboCoordinates);
                    houses.Add(roboCoordinates);
                }

                
            }

            return houses.Count;
        }

        (int x, int y) IncrementCoordinates(char c, (int x, int y) coordinates)
        {
            switch (c)
            {
                case '>' :
                    coordinates.x++;
                    break;
                case '^' :
                    coordinates.y--;
                    break;
                case '<' :
                    coordinates.x--;
                    break;
                case 'v' :
                    coordinates.y++;
                    break;
            }

            return coordinates;
        }
    }
}
