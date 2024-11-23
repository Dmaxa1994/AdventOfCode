using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day02
{
	public class CubeConundrum
	{
		private readonly string[] _puzzleData = File.ReadAllLines(@"2023\day02\PuzzleData.txt");
		
		const int RedTotal = 12;
		const int BlueTotal = 14;
		const int GreenTotal = 13;

		public int GetSumOfValidGames()
		{
			var total = 0;
			foreach (var line in _puzzleData)
			{
				var game = line.Split(":");
				var id = int.Parse(Regex.Replace(game[0], "[a-zA-Z]", "").Trim());

				var gameSubsets = game[1].Split(";");
				var gameValid = true;
				foreach (var subset in gameSubsets)
				{
					if (!gameValid)
						break;

					var cubes = subset.Split(",");
		
					foreach (var cube in cubes)
					{
						var cubeData = cube.Trim().Split(" ");
						var cubeColour = cubeData[1];
						var cubeCount = int.Parse(cubeData[0]);
						switch (cubeColour.ToLower())
						{
							case "red":
								if(cubeCount > RedTotal)
									gameValid = false;
								break;
							case "blue":
								if(cubeCount > BlueTotal)
									gameValid = false;
								break;
							case "green":
								if(cubeCount > GreenTotal)
									gameValid = false;
								break;
						}
					}
				}

				if (gameValid)
					total += id;
			}

			return total;
		}

		public int GetSumOfPowers()
		{
			var total = 0;
			foreach (var line in _puzzleData)
			{
				var game = line.Split(":");

				var gameSubsets = game[1].Split(";");
				var highestRedCubeCount = 1;
				var highestBlueCubeCount = 1;
				var highestGreenCubeCount = 1;
				foreach (var subset in gameSubsets)
				{
					var cubes = subset.Split(",");
		
					foreach (var cube in cubes)
					{
						var cubeData = cube.Trim().Split(" ");
						var cubeColour = cubeData[1];
						var cubeCount = int.Parse(cubeData[0]);
						switch (cubeColour.ToLower())
						{
							case "red":
								if (cubeCount > highestRedCubeCount)
								{
									highestRedCubeCount = cubeCount;
								}
								break;
							case "blue":
								if (cubeCount > highestBlueCubeCount)
								{
									highestBlueCubeCount = cubeCount;
								}
								break;
							case "green":
								if (cubeCount > highestGreenCubeCount)
								{
									highestGreenCubeCount = cubeCount;
								}
								break;
						}
					}
				}

				var power = highestRedCubeCount * highestBlueCubeCount * highestGreenCubeCount;
				total += power;

			}

			return total;
		}
	}
}
