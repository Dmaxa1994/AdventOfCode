namespace AdventOfCode._2023.Day06
{
	public class BoatRace
	{
		public long Part1()
		{
			var times = new[] { 56L, 97L, 78L, 75L };
			var distances = new[] { 546L, 1927L, 1131L, 1139L };

			return WaysToWin(times, distances);
		}

		public long Part2()
		{
			var times = new[] { 56977875L };
			var distances = new[] { 546192711311139L };

			return WaysToWin(times, distances);
		}

		private long WaysToWin(long[] times, long[] distances)
		{
			var total = 1;

			for (var i = 0; i < times.Length; i++)
			{
				var raceTime = times[i];
				var minimumDistance = distances[i];
				var waysToWin = 0;
				for (var holdTime = 0; holdTime < raceTime; holdTime++)
				{
					var remainingTime = raceTime - holdTime;
					var travelledDistance = holdTime * remainingTime;
					if (travelledDistance > minimumDistance)
					{
						waysToWin++;
					}
				}
				total *= waysToWin;
			}

			return total;
		}
	}
}
