namespace AdventOfCode._2023.Day08
{
	public class HauntedWasteland
	{
		private readonly string _directions =
			"LRRLLRRLLRRRLRLRRLRLRLRRLRLRLRLLLRRRLRLRRLLRLRRRLRRRLRLRLRRRLLRRLLRLRLRRRLRLLRRRLRLLRLRRRLRLRRRLRRRLLRRRLLRRRLRRLRRRLLRRRLRRLRRLRRLLRLRRLRRLRRRLRLRLRLRLRLRRRLLRLRRLRLRRLLRRLLRLRRLRRRLRLRLRLRRRLRRLRRLRRLRRLRRLRLRRRLRRRLRRRLRLRLLRRLRRRLRRLRLRRRLRRLRRRLRRLLRRLLLRRRR";

		private readonly string[] _nodes = File.ReadAllLines(@"2023\day08\PuzzleData.txt");

		public long Part1()
		{
			var steps = 0;
			var i = 0;
			var nextNode = "";
			while(nextNode != "ZZZ")
			{
				if (steps == 18673)
				{
					string ab = "tr";
				}
				if (i == _directions.Length)
				{
					i = 0;
				}

				var direction = _directions[i];
				var node = "";
				if (steps == 0)
				{
					node = _nodes.FirstOrDefault("AAA");
				}
				else
				{
					node = _nodes.FirstOrDefault(x => x.StartsWith(nextNode));
				}

				var nextNodes = node.Split("(")[1].Replace(")", "").Split(",", StringSplitOptions.TrimEntries);

				switch (direction)
				{
					case 'L':
						nextNode = nextNodes[0];
						break;
					case 'R':
						nextNode = nextNodes[1];
						break;
				}

				steps++;
				i++;
			}

			return steps;
		}

		public long Part2()
		{
			return 0;
		} 
	}
}
