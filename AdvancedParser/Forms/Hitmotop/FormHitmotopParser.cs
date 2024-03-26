using AdvancedParser.Core;
using AdvancedParser.Excel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AdvancedParser.Core.Hitmotop;
using System.Drawing;
using System.Linq;

namespace AdvancedParser.Forms.Hitmotop
{
	public partial class FormHitmotopParser : Form
	{
		ParserWorker<Dictionary<string, string>> Parser { get; }

		Font CurrentFont { get; }

		public FormHitmotopParser()
		{
			InitializeComponent();

			Parser = new ParserWorker<Dictionary<string, string>>(
					new HitmotopParser()
				);

			Load += FormHitmotopParser_Load;
			Parser.OnCompleted += Parser_OnCompleted;
			Parser.OnNewData += Parser_OnNewData;
		}

		public FormHitmotopParser(Font font) : this()
		{
			CurrentFont = font;
		}

		private void FormHitmotopParser_Load( object sender, EventArgs e)
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
			// Добавление проверки на уникальность из-за особенностей сайта
			var firstElement = arg2.First();
			ListItem<string, string> firstItem = new ListItem<string, string>(firstElement.Key, firstElement.Value);
			if (ListTitles.Items.Cast<ListItem<string, string>>()
				.Any(item => item.Key == firstItem.Key && item.Value == firstItem.Value))
			{
				MessageManager.Show("The data is repeated\nThe parsing has been stopped");
				Parser.Abort();
				return;
			}

			foreach (var pair in arg2)
			{
				ListTitles.Items.Add(new ListItem<string, string>(pair.Key, pair.Value));
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
			Parser.Settings = new HitmotopSettings((int)NumericStart.Value, (int)NumericCount.Value);
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
				new Header(text: "Название", width: 50),
				new Header(text: "Автор", width: 50),
				new Header(text: "Ссылка", width: 70, hasHyperlink: true),
			};
			var data = new string[ListTitles.Items.Count, headers.Length];

			for (int i = 0; i < ListTitles.Items.Count; i++)
			{
				ListItem<string, string> item = (ListItem<string, string>)ListTitles.Items[i];
				var splitedItemValue = item.Key.Split('\n');
				var name = splitedItemValue[0];
				var author = splitedItemValue[1];

				data[i, 0] = name;
				data[i, 1] = author;
				data[i, 2] = $"{Parser.Settings.BaseUrl}{item.Value}";
			}

			ExcelSaver.SaveToExcel(headers, data, 1, 1, "HitmotopParser");
		}
	}
}
