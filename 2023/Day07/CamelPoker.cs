namespace AdventOfCode._2023.Day07
{
	public class CamelPoker
	{
		private enum Hand
		{
			HighCard,
			Pair,
			TwoPair,
			ThreeOfAKind,
			FullHouse,
			FourOfAKind,
			FiveOfAKing
		}

		public long Part1()
		{
			var handsAndBets = new List<string> {"32T3K 765", "T55J5 684", "KK677 28", "KTJJT 220", "QQQJA 483"};
			var rankings = new Dictionary<Hand, int>();

			foreach (var handAndBet in handsAndBets)
			{
				var hand = handAndBet.Split(" ")[0];
				var bet = int.Parse(handAndBet.Split(" ")[1]);
				var cards = new Dictionary<char, int>();
				foreach (var card in hand)
				{
					if (cards.ContainsKey(card))
					{
						cards[card]++;
					}
					else
					{
						cards.Add(card, 1);
					}
				}
			}

			return 0;
		}

		private void CalculateHand()
		{

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
