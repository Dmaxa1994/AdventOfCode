using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode._2023.Day03
{
    public class GearRatios
    {
        private readonly string[] _puzzleData = File.ReadAllLines(@"2023\day03\PuzzleData.txt");


        public int SumOfPartNumbers()
        {
            var sum = 0;
            var visited = new HashSet<(int, int)>();

            for (var i = 0; i < _puzzleData.Length; i++)
            {
                for (var j = 0; j < _puzzleData[i].Length; j++)
                {
                    if (char.IsDigit(_puzzleData[i][j]) && !visited.Contains((i, j)))
                    {
                        var (number, coordinates) = ExtractNumber(_puzzleData, i, j, visited);
                        if (IsAdjacentToSymbol(_puzzleData, coordinates))
                        {
                            sum += number;
                        }
                    }
                }
            }

            return sum;
        }


        private bool IsAdjacentToSymbol(string[] lines, List<(int, int)> coordinates)
        {
            foreach (var (x, y) in coordinates)
            {
                if (IsCellAdjacentToSymbol(lines, x, y))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsCellAdjacentToSymbol(string[] lines, int x, int y)
        {
            int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (var i = 0; i < 8; i++)
            {
                var adjX = x + dx[i];
                var adjY = y + dy[i];

                if (adjX >= 0 && adjX < lines.Length && adjY >= 0 && adjY < lines[adjX].Length)
                {
                    var adjacentChar = lines[adjX][adjY];
                    if (!char.IsDigit(adjacentChar) && adjacentChar != '.')
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private (int Number, List<(int, int)> Coordinates) ExtractNumber(string[] lines, int x, int y, HashSet<(int, int)> visited)
        {
            var number = "";
            var coordinates = new List<(int, int)>();
            while (y < lines[x].Length && char.IsDigit(lines[x][y]))
            {
                visited.Add((x, y));
                number += lines[x][y];
                coordinates.Add((x, y));
                y++;
            }
            return (int.Parse(number), coordinates);
        }

        public int Part1()
        {
            var validatedPartNumbers = new List<PartNumber>();
            for (var i = 2; i < _puzzleData.Length; i++)
            {
                var line1 = _puzzleData[i - 2];
                var line2 = _puzzleData[i - 1];
                var line3 = _puzzleData[i];

                var line1PartNumbers = FindNumbersInLine(line1, i - 2);
                var line2PartNumbers = FindNumbersInLine(line2, i - 1);
                var line3PartNumbers = FindNumbersInLine(line3, i);

                var line1Symbols = FindSymbolInLine(line1);
                var line2Symbols = FindSymbolInLine(line2);
                var line3Symbols = FindSymbolInLine(line3);

                validatedPartNumbers.AddRange(FindPartNumbers(line1PartNumbers, line1Symbols));
                validatedPartNumbers.AddRange(FindPartNumbers(line1PartNumbers, line2Symbols));

                validatedPartNumbers.AddRange(FindPartNumbers(line2PartNumbers, line1Symbols));
                validatedPartNumbers.AddRange(FindPartNumbers(line2PartNumbers, line2Symbols));
                validatedPartNumbers.AddRange(FindPartNumbers(line2PartNumbers, line3Symbols));

                validatedPartNumbers.AddRange(FindPartNumbers(line3PartNumbers, line2Symbols));
                validatedPartNumbers.AddRange(FindPartNumbers(line3PartNumbers, line3Symbols));
            }

            return validatedPartNumbers.Sum(x => x.Number);
        }

        public int Part2()
        {
            var sample = "467..114..\r\n...*......\r\n..35..633.\r\n......#...\r\n617*......\r\n.....+.58.\r\n..592.....\r\n......755.\r\n...$.*....\r\n.664.598..".Split("\r\n");
            
            var validatedPartNumbers = new List<(PartNumber, PartNumber)>();
            for (var i = 2; i < sample.Length; i++)
            {
                var line1 = sample[i - 2];
                var line2 = sample[i - 1];
                var line3 = sample[i];

                var line1PartNumbers = FindNumbersInLine(line1, i - 2);
                var line2PartNumbers = FindNumbersInLine(line2, i - 1);
                var line3PartNumbers = FindNumbersInLine(line3, i);

                var line1Symbols = FindSymbolInLine(line1).Where(x => x.Character == "*").ToList();
                var line2Symbols = FindSymbolInLine(line2).Where(x => x.Character == "*").ToList();
                var line3Symbols = FindSymbolInLine(line3).Where(x => x.Character == "*").ToList();

                validatedPartNumbers.AddRange(FindGearNumbers(line1PartNumbers, line1Symbols));
                validatedPartNumbers.AddRange(FindGearNumbers(line1PartNumbers, line2Symbols));

                validatedPartNumbers.AddRange(FindGearNumbers(line2PartNumbers, line1Symbols));
                validatedPartNumbers.AddRange(FindGearNumbers(line2PartNumbers, line2Symbols));
                validatedPartNumbers.AddRange(FindGearNumbers(line2PartNumbers, line3Symbols));

                validatedPartNumbers.AddRange(FindGearNumbers(line3PartNumbers, line2Symbols));
                validatedPartNumbers.AddRange(FindGearNumbers(line3PartNumbers, line3Symbols));
            }

            
            return validatedPartNumbers.Sum(x => x.Item1.Number * x.Item2.Number);
        }

        private List<PartNumber> FindPartNumbers(List<PartNumber> partNumbers, List<Symbol> symbols)
		{
            var validatedPartNumbers = new List<PartNumber>();
			foreach (var symbol in symbols)
			{
				var validPartNumbers = partNumbers.Where(x => IsInRangeOfSymbol(x.StartIndex, x.EndIndex, symbol.Index));
				foreach (var vpn in validPartNumbers)
				{
					var existing = validatedPartNumbers.FirstOrDefault(x => x.FullEquals(vpn));
					if (existing == null)
					{
						validatedPartNumbers.Add(vpn);
					}
				}
			}

            return validatedPartNumbers;
        }

        private List<(PartNumber, PartNumber)> FindGearNumbers(List<PartNumber> partNumbers, List<Symbol> symbols)
        {
            var gearNos = new List<(PartNumber, PartNumber)>();
            foreach (var symbol in symbols)
            {
                var validPartNumbers = partNumbers.Where(x => IsInRangeOfSymbol(x.StartIndex, x.EndIndex, symbol.Index)).ToList();
                if (validPartNumbers.Count != 2) continue;
                var gear = (validPartNumbers[0], validPartNumbers[1]);
                var existing = false;
                foreach (var item in gearNos)
                {
                    if (gear.Item1.FullEquals(item.Item1) && gear.Item2.FullEquals(item.Item2))
                        existing = true;
                }
                if (!existing)
                {
                    gearNos.Add(gear);
                }
            }

            return gearNos;
        }

		private static bool IsInRangeOfSymbol(int partNumStartIndex, int partNumEndIndex, int symbolIndex)
		{
			if (symbolIndex == partNumStartIndex || symbolIndex == partNumEndIndex)
				return true;

			if (partNumStartIndex == symbolIndex - 1)
				return true;

			if (partNumStartIndex == symbolIndex + 1)
				return true;

			if (partNumEndIndex == symbolIndex - 1)
				return true;

			if (partNumEndIndex == symbolIndex + 1)
				return true;

			return false;
		}

		List<PartNumber> FindNumbersInLine(string line, int lineNo)
		{
			var matches = Regex.Matches(line, "[0-9]+", RegexOptions.IgnoreCase);
			var results = new List<PartNumber>();
			var sortedMatches = matches.GroupBy(x => x.Value).ToList();
			foreach (var match in sortedMatches)
			{
				var startIndex = 0;
				while ((startIndex = line.IndexOf(match.Key, startIndex, StringComparison.InvariantCulture)) != -1)
				{
					if (startIndex != 0)
					{
						var before = line[startIndex-1];

						if (char.IsDigit(before))
						{
							startIndex++;
							continue;
						}
					}

					if (startIndex + match.Key.Length <= line.Length - 1)
					{
						var after = line[startIndex + match.Key.Length];

						if (char.IsDigit(after))
						{
							startIndex++;
							continue;
						}
					}

					results.Add(new PartNumber
					{
						LineNo = lineNo,
						Number = int.Parse(match.Key),
						StartIndex = startIndex,
						EndIndex = startIndex + match.Key.Length - 1
					});
					startIndex++;
				}
			}

			return results;
		}

		List<Symbol> FindSymbolInLine(string line)
		{
			var matches = Regex.Matches(line, "[^a-zA-Z0-9.]", RegexOptions.IgnoreCase);
			var results = new List<Symbol>();
			var sortedMatches = matches.GroupBy(x => x.Value).ToList();
			foreach (var match in sortedMatches)
			{
				var startIndex = 0;
				while ((startIndex = line.IndexOf(match.Key, startIndex, StringComparison.InvariantCulture)) != -1)
				{
					results.Add(new Symbol
					{
						Character = match.Key,
						Index = startIndex
					});
					startIndex++;
				}
			}

			return results;
		}
    }
}
