﻿using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdvancedParser.Core
{
	internal class HtmlLoader
	{
		readonly HttpClient client;
		readonly string url;

		public HtmlLoader(IParserSettings settings)
		{
			client = new HttpClient();
			url = $"{settings.BaseUrl}/{settings.Prefix}";
		}

		public async Task<string> GetSourceByPageId(int id)
		{
			var currentUrl = url.Replace("{CurrentId}", id.ToString());
			Console.WriteLine(currentUrl);
			var response = await client.GetAsync(currentUrl);
			
			string source = null;

			if (response != null && response.StatusCode == HttpStatusCode.OK)
			{
				source = await response.Content.ReadAsStringAsync();
			}

			return source;
		}
	}
}
