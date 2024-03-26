using System;
using System.Windows.Forms;

namespace AdvancedParser.Forms
{
	public static class MessageManager
	{
		public static bool ShowGuiMessages { get; set; }

		public static void Show(string text)
		{
			Console.WriteLine(text);

			if (ShowGuiMessages) MessageBox.Show(text);
		}
	}
}
