using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2023.Day04
{
	public class Card
	{
		public string CardNo { get; set; }
		public int Quantity { get; set; }
		public string[] WinningNumbers { get; set; } = [];
		public string[] GameNumbers { get; set; } = [];
		public string[] MatchedNumbers { get; set; } = [];

		public override string ToString()
		{
			return $"{CardNo} x{Quantity}";
		}
	}
}
