using AdvancedParser.Core;
using AdvancedParser.Core.Habr;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AdvancedParser.Forms.Habr
{
	public partial class FormHabrParser : Form
	{
		ParserWorker<Dictionary<string, string>> Parser { get; }

		Font CurrentFont { get; }

		public FormHabrParser()
		{
			InitializeComponent();

			Parser = new ParserWorker<Dictionary<string, string>>(
					new HabrParser()
				);

			Load += FormHabrParser_Load;
			Parser.OnCompleted += Parser_OnCompleted;
			Parser.OnNewData += Parser_OnNewData;
		}

		public FormHabrParser(Font font) : this()
		{
			CurrentFont = font;
		}

		private void FormHabrParser_Load(object sender, EventArgs e)
		{
			FormsExtension.ApplyFontToAllControls(this, CurrentFont);

			ListTitles.DrawMode = DrawMode.OwnerDrawFixed;
			ListTitles.DrawItem += ListTitles_DrawItem;
		}

		private void ListTitles_DrawItem(object sender, DrawItemEventArgs e)
		{
			FormsExtension.List_DrawItem_MultipleLines(sender, e);
		}

		private void Parser_OnNewData(object arg1, Dictionary<string, string> arg2)
		{
			foreach (var pair in arg2)
			{
				ListTitles.Items.Add(new ListItem(pair.Key, pair.Value));
			}
		}

		private void Parser_OnCompleted(object obj)
		{
			MessageBox.Show($"{Name} done!");
		}

		private void ListTitles_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			ListItem selectedItem = ListTitles.SelectedItem as ListItem;

			if (selectedItem != null && selectedItem.Value != null)
			{
				System.Diagnostics.Process.Start($"{Parser.Settings.BaseUrl}{selectedItem.Value}");
			}
		}

		private void ButtonStart_Click(object sender, EventArgs e)
		{
			Parser.Settings = new HabrSettings((int)NumericStart.Value, (int)NumericCount.Value);
			Parser.Start();
		}

		private void ButtonAbort_Click(object sender, EventArgs e)
		{
			Parser.Abort();
		}

		private void ButtonClearResult_Click(object sender, EventArgs e)
		{
			ListTitles.Items.Clear();
		}
	}
}
