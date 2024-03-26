namespace AdvancedParser.Core.Habr
{
	internal class HabrSettings : IParserSettings
	{
		public HabrSettings(int start, int count)
		{
			StartPoint = start;
			CountOfPoints = count;
		}

		public string BaseUrl { get; set; } = "https://habr.com";
		public string Prefix { get; set; } = "ru/feed/page{CurrentId}";
		public int StartPoint { get; set; }
		public int CountOfPoints { get; set; }
		public int PageIncrement { get; set; } = 1;
	}
}
