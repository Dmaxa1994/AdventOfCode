namespace AdventOfCode._2015.Day02
{
    public class Wrapping(string puzzlePath)
    {
        private readonly string[] _puzzleData = File.ReadAllLines(puzzlePath);

        public int Part1()
        {
            var requiredWrappingPaper = 0;
            foreach (var line in _puzzleData)
            {
                var dimensions = line.Split("x");
                var length = int.Parse(dimensions[0]);
                var width = int.Parse(dimensions[1]);
                var height = int.Parse(dimensions[2]);

                var areas = new List<int>
                {
                    length * width,
                    width * height,
                    height * length
                };

                requiredWrappingPaper += areas.Min() + areas.Sum(area => 2 * area);
            }

            return requiredWrappingPaper;
        }

        public int Part2()
        {
            var ribbonFt = 0;

            foreach (var line in _puzzleData)
            {
                var dimensions = line.Split("x");
                var length = int.Parse(dimensions[0]);
                var width = int.Parse(dimensions[1]);
                var height = int.Parse(dimensions[2]);

                var volume = length * width * height;

                var areas = new List<int>
                {
                    length,
                    width,
                    height,
                };
                var max = areas.Max();
                areas.Remove(max);

                ribbonFt += volume + areas.Sum(area => 2 * area);
            }

            return ribbonFt;
        }
    }
}
