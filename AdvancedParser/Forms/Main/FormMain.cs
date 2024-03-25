using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AdvancedParser.Forms.Main
{
	public partial class FormMain : Form
	{
		private Dictionary<string, Form> forms;
		
		Font CurrentFont {  get; set; }

		public FormMain(Dictionary<string, Form> forms, Font font)
		{
			InitializeComponent();

			this.forms = forms;
			CurrentFont = font;
		}

		private void FormMain_Load(object sender, EventArgs e)
		{
			FormsExtension.ApplyFontToAllControls(this, CurrentFont);

			foreach (var form in forms)
			{
				ListParsers.Items.Add(form.Key);
			}
		}

		private void ListParsers_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			string selectedItem = ListParsers.SelectedItem as string;

			if (selectedItem != null)
			{
				Form form = forms[selectedItem];

				Form newForm = Activator.CreateInstance(form.GetType(), CurrentFont) as Form;
				newForm.Show();
			}
		}
	}
}
