namespace AdventOfCode._2023.Day04
{
	public class Scratchcards
	{
		private readonly string[] _puzzleData = File.ReadAllLines(@"2023\day04\PuzzleData.txt");

		private Card BuildCard(string line)
		{
			var lineParts = line.Split(":", StringSplitOptions.TrimEntries);
			var cardNum = lineParts[0];
			var cardData = lineParts[1];
			var cardParts = cardData.Split("|");
			var winningNumbers = cardParts[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
			var gameNumbers = cardParts[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);

			return new Card
			{
				CardNo = cardNum,
				Quantity = 1,
				WinningNumbers = winningNumbers,
				GameNumbers = gameNumbers
			};
		}

		private string[] GetMatchedNumbers(Card card)
		{
			var matchedNumbers = new List<string>();
			foreach (var gameNumber in card.GameNumbers)
			{
				if (card.WinningNumbers.Contains(gameNumber))
				{
					matchedNumbers.Add(gameNumber);
				}
			}

			return matchedNumbers.ToArray();
		}

		public int GetScratchCardTotals()
		{
			var total = 0;
			foreach (var line in _puzzleData)
			{
				var card = BuildCard(line);

				var matchedNumbers = GetMatchedNumbers(card);

				var gameTotal = 0;
				foreach (var _ in matchedNumbers)
				{
					if (gameTotal == 0)
					{
						gameTotal++;
					}
					else
					{
						gameTotal *= 2;
					}
				}

				total += gameTotal;
			}

			return total;
		}

		public int CalculateTotalNumberOfCards()
		{
			var cards = new List<Card>();
			foreach (var line in _puzzleData)
			{
				var card = BuildCard(line);
				card.MatchedNumbers = GetMatchedNumbers(card);
				cards.Add(card);
			}

			var total = 0;
			for (var i = 0; i < cards.Count; i++)
			{
				var card = cards[i];
				total += card.Quantity;
				for (var j = 1; j <= card.MatchedNumbers.Length; j++)
				{
					var k = i + j;
					if (k < cards.Count)
					{
						cards[k].Quantity += card.Quantity;
					}
				}
			}

			return total;
		}
	}
}
