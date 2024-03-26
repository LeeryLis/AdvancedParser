namespace AdvancedParser.Core.Hitmotop
{
	internal class HitmotopSettings : IParserSettings
	{
		public HitmotopSettings(int start, int count)
		{
			StartPoint = start;
			CountOfPoints = count;
		}

		public string BaseUrl { get; set; } = "https://rus.hitmotop.com";
		public string Prefix { get; set; } = "songs/top-today/start/{CurrentId}";
		public int StartPoint { get; set; }
		public int CountOfPoints { get; set; }
		public int PageIncrement { get; set; } = 48;
	}
}
