using AdvancedParser.Forms;
using AdvancedParser.Forms.Habr;
using AdvancedParser.Forms.Hitmotop;
using AdvancedParser.Forms.Main;
using AdvancedParser.Settings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AdvancedParser
{
	internal static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			AppConfiguration config = AppConfigurationManager.LoadConfiguration();

			MessageManager.ShowGuiMessages = config.ShowGuiMessages;

			Dictionary<string, Form> forms = new Dictionary<string, Form>
			{
				["Habr"] = new FormHabrParser(),
				["Hitmotop"] = new FormHitmotopParser(),
			};

			Font font = new Font(config.FontName, config.FontSize);
			Application.Run(new FormMain(forms, font));
		}
	}
}
