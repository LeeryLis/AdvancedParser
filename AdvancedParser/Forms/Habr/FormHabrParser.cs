using AdvancedParser.Core;
using AdvancedParser.Core.Habr;
using AdvancedParser.Excel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
			if (arg2.Count == 0)
			{
				MessageManager.Show("The data is empty\nThe parsing has been stopped");
				Parser.Abort();
				return;
			}

			foreach (var pair in arg2)
			{
				var item = new ListItem<string, string>(pair.Key, pair.Value);
				ListTitles.Items.Add(item);
			}
		}

		private void Parser_OnCompleted(object obj)
		{
			MessageManager.Show($"{Name} done!");
		}

		private void ListTitles_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			var selectedItem = ListTitles.SelectedItem as ListItem<string, string>;

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

		private void ButtonSaveExcel_Click(object sender, EventArgs e)
		{
			if (Parser.IsActive)
			{
				MessageManager.Show("The work is not finished yet!");
				return;
			}

			if (ListTitles.Items.Count <= 0)
			{
				MessageManager.Show("List is empty!");
				return;
			}

			Header[] headers = { 
				new Header(text: "Название статьи", width: 100),
				new Header(text: "Ссылка", width: 70, hasHyperlink: true),
			};
			var data = new string[ListTitles.Items.Count, headers.Length];

			for (int i = 0; i < ListTitles.Items.Count; i++)
			{
				ListItem<string, string> item = (ListItem<string, string>)ListTitles.Items[i];
				data[i, 0] = item.Key;
				data[i, 1] = $"{Parser.Settings.BaseUrl}{item.Value}";
			}

			ExcelSaver.SaveToExcel(headers, data, 1, 1, "HabrParser");
		}
	}
}
