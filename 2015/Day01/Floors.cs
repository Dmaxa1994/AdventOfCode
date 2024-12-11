namespace AdventOfCode._2015.Day01
{
    public class Floors(string puzzlePath)
    {
        private readonly string _puzzleData = File.ReadAllText(puzzlePath);

        public int Part1()
        {
            var floor = 0;
            foreach (var c in _puzzleData)
            {
                switch (c)
                {
                    case '(' :
                        floor++;
                        break;
                    case ')':
                        floor--;
                        break;
                }
            }

            return floor;
        }

        public int Part2()
        {
            var floor = 0;
            for (var i = 0; i < _puzzleData.Length; i++)
            {
                var c = _puzzleData[i];
                switch (c)
                {
                    case '(' :
                        floor++;
                        break;
                    case ')':
                        floor--;
                        break;
                }

                if (floor == -1)
                    return i + 1;
            }

            return 0;
        }
    }
}
