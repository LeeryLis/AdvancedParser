﻿using AdvancedParser.Core;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AdvancedParser.Core.Hitmotop;
using System.Drawing;

namespace AdvancedParser.Forms.Hitmotop
{
	public partial class FormHitmotopParser : Form
	{
		ParserWorker<Dictionary<string, string>> parser;

		Font CurrentFont { get; set; }

		public FormHitmotopParser(Font font)
		{
			InitializeComponent();

			parser = new ParserWorker<Dictionary<string, string>>(
					new HitmotopParser()
				);
			CurrentFont = font;

			Load += FormHitmotopParser_Load;
			parser.OnCompleted += Parser_OnCompleted;
			parser.OnNewData += Parser_OnNewData;
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
				System.Diagnostics.Process.Start($"{parser.Settings.BaseUrl}{selectedItem.Value}");
			}
		}

		private void ButtonStart_Click(object sender, EventArgs e)
		{
			parser.Settings = new HitmotopSettings((int)NumericStart.Value, (int)NumericEnd.Value);
			parser.Start();
		}

		private void ButtonAbort_Click(object sender, EventArgs e)
		{
			parser.Abort();
		}

		private void ButtonClearResult_Click(object sender, EventArgs e)
		{
			ListTitles.Items.Clear();
		}
	}
}