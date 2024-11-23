using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day01
{
	public class Trebuchet
	{
		private readonly string[] _puzzleData = File.ReadAllLines(@"2023\day01\PuzzleData.txt");
		public int GetTotal()
		{
			var total = 0;

			foreach (var line in _puzzleData)
			{
				var numbers = Regex.Replace(line, "[a-zA-Z]", "").ToCharArray();
				var first = numbers.First().ToString();
				var last = numbers.Last().ToString();

				total += int.Parse(first + last);
			}

			return total;
		}

		public int GetTotalWithWords()
		{
			var total = 0;
			var validNumbers = new Dictionary<string, string>
			{
				{ "one", "1" },
				{ "two", "2" },
				{ "three", "3" },
				{ "four", "4" },
				{ "five", "5" },
				{ "six", "6" },
				{ "seven", "7" },
				{ "eight", "8" },
				{ "nine", "9" }
			};

			foreach (var line in _puzzleData)
			{
				var regexPattern = @"(?=(one|two|three|four|five|six|seven|eight|nine|\d))";

				var matches = Regex.Matches(line, regexPattern, RegexOptions.IgnoreCase);

				if (matches.Count > 0)
				{
					var first = matches.First().Groups.Values.First(x => !string.IsNullOrWhiteSpace(x.Value)).Value;
					var last = matches.Last().Groups.Values.First(x => !string.IsNullOrWhiteSpace(x.Value)).Value;

					if (validNumbers.ContainsKey(first))
						first = validNumbers[first];
					if (validNumbers.ContainsKey(last))
						last = validNumbers[last];

					total += int.Parse(first + last);
				}
			}

			return total;
		}
	}
}
