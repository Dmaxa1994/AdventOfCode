namespace AdventOfCode._2023.Day03
{
	internal class Symbol
	{
		public string Character { get; set; }

		public int Index { get; set; }

		public int LineNo { get; set; }

		public override bool Equals(object? obj)
		{
			var other = obj as Symbol;
			if (other == null) return false;

			if (this.Index != other.Index) return false;

			if(this.LineNo != other.LineNo) return false;

			return true;
		}
	}
}
