namespace AdventOfCode._2024.Day02
{
    public class RedNosedReports
    {
        private readonly string[] _puzzleData = File.ReadAllLines(@"2024\day02\PuzzleData.txt");


        public int Part1()
        {
            return _puzzleData.Count(line => IsValidReport(line.Split(" ")));
        }

        private bool IsValidReport(string[] reportData)
        {
            var isIncreasing = false;
            var directionSet = false;
            for (var i = 1; i < reportData.Length; i++)
            {
                var prev = int.Parse(reportData[i - 1]);
                var curr = int.Parse(reportData[i]);

                if (curr == prev)
                    return false;

                if (Math.Abs(curr - prev) > 3)
                    return false;

                if (!directionSet)
                {
                    if (curr > prev)
                    {
                        isIncreasing = true;
                        directionSet = true;
                    }
                    else if (curr < prev)
                    {
                        isIncreasing = false;
                        directionSet = true;
                    }
                }
                else
                {
                    // Validate the direction
                    if (isIncreasing && curr < prev)
                        return false;

                    if (!isIncreasing && curr > prev)
                        return false;
                }
            }

            return true;
        }

        public int Part2()
        {
            var validCount = 0;
            foreach (var line in _puzzleData)
            {
                var reportData = line.Split(" ");

                if (IsValidReport(reportData))
                {
                    validCount++;
                    continue;
                }

                // Attempt to fix the report by removing one number
                if (CanBeFixed(reportData))
                {
                    validCount++;
                }
            }

            return validCount;
        }

        private bool CanBeFixed(string[] reportData)
        {
            for (var i = 0; i < reportData.Length; i++)
            {
                var modified = reportData.Where((_, idx) => idx != i).ToArray();

                if (IsValidReport(modified))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
