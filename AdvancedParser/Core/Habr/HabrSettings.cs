namespace AdvancedParser.Core.Habr
{
	internal class HabrSettings : IParserSettings
	{
		public HabrSettings(int start, int end)
		{
			StartPoint = start;
			EndPoint = end;
		}

		public string BaseUrl { get; set; } = "https://habr.com";
		public string Prefix { get; set; } = "ru/feed/page{CurrentId}";
		public int StartPoint { get; set; }
		public int EndPoint { get; set; }
		public int PageIncrement { get; set; } = 1;
	}
}
