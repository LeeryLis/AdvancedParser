using AngleSharp.Html.Dom;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedParser.Core.Habr
{
	internal class HabrParser : IParser<Dictionary<string, string>>
	{
		public Dictionary<string, string> Parse(IHtmlDocument document)
		{
			var dict = new Dictionary<string, string>();
			var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("tm-title__link"));

			foreach (var item in items)
			{
				dict[item.TextContent] = item.GetAttribute("href");
			}

			return dict;
		}
	}
}
