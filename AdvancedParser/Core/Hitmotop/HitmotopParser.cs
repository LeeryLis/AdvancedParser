using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedParser.Core.Hitmotop
{
	internal class HitmotopParser : IParser<Dictionary<string, string>>
	{
		public Dictionary<string, string> Parse(IHtmlDocument document)
		{
			var dict = new Dictionary<string, string>();
			var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("track__info-l"));

			foreach (var item in items)
			{
				var title = item.QuerySelector(".track__title");
				var desc = item.QuerySelector(".track__desc");
				dict[$"{title.TextContent.Trim()}\n{desc.TextContent.Trim()}"] = item.GetAttribute("href");
			}

			return dict;
		}
	}
}
