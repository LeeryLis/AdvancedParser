using AdvancedParser.Forms.Habr;
using AdvancedParser.Forms.Hitmotop;
using AdvancedParser.Forms.Main;
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

			Font font = new Font("Arial", 12);
			Dictionary<string, Form> forms = new Dictionary<string, Form>
			{
				["Habr"] = new FormHabrParser(font),
				["Hitmotop"] = new FormHitmotopParser(font),
			};

			Application.Run(new FormMain(forms, font));
		}
	}
}
