namespace AdvancedParser.Excel
{
	public class Header
	{
		public string Text { get; }
		public double Width { get; }
		public bool IsCenterAligned { get; }
		public bool HasHyperlink { get; }

		public Header(string text, double width = 8.43, bool isCenterAligned = false, bool hasHyperlink = false)
		{
			Text = text;
			Width = width;
			IsCenterAligned = isCenterAligned;
			HasHyperlink = hasHyperlink;
		}
	}
}
