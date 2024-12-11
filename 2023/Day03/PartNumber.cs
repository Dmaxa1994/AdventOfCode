namespace AdventOfCode._2023.Day03
{
	internal class PartNumber
	{
		public int LineNo { get; set; }
		public int Number { get; set; }
		public int StartIndex { get; set; }
		public int EndIndex { get; set; }

		public bool FullEquals(object? obj)
		{
			var other = obj as PartNumber;
			if(other == null) return false;

			if (this.LineNo != other.LineNo)
				return false;

			if (this.Number != other.Number)
				return false;

			if (this.StartIndex != other.StartIndex)
				return false;

			if (this.EndIndex != other.EndIndex)
				return false;

			return true;
		}

		public override bool Equals(object? obj)
		{
			var other = obj as PartNumber;
			if(other == null) return false;

			if (this.LineNo != other.LineNo)
				return false;

			if (this.Number != other.Number)
				return false;

			return true;
		}

		public override string ToString()
		{
			return $"line: {LineNo} Num: {Number}";
		}
	}
}
