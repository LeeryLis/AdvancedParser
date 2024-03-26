using Newtonsoft.Json;
using System.IO;
using System;

namespace AdvancedParser.Settings
{
	public static class AppConfigurationManager
	{
		public static string ConfigFilePath { get; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings", "config.json");

		public static AppConfiguration LoadConfiguration()
		{
			if (!File.Exists(ConfigFilePath))
			{
				return new AppConfiguration();
			}

			string json = File.ReadAllText(ConfigFilePath);
			return JsonConvert.DeserializeObject<AppConfiguration>(json);
		}
	}
}
