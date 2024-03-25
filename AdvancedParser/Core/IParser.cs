using AngleSharp.Html.Dom;

namespace AdvancedParser.Core
{
	internal interface IParser<T> where T : class
	{
		T Parse(IHtmlDocument doucument);
	}
}
