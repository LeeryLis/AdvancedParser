﻿namespace AdvancedParser.Core
{
	internal interface IParserSettings
	{
		string BaseUrl { get; set; }
		string Prefix { get; set; }
		int StartPoint { get; set; }
		int EndPoint { get; set; }
		int PageIncrement { get; set; }
	}
}
