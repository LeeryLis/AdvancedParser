using System.Drawing;
using System.Windows.Forms;

namespace AdvancedParser.Forms
{
	public static class FormsExtension
	{
		public static void List_DrawItem_MultipleLines(object sender, DrawItemEventArgs e)
		{
			ListBox listBox = sender as ListBox;

			e.DrawBackground();
			if (e.Index >= 0)
			{
				string itemText = listBox.Items[e.Index].ToString();
				string[] lines = itemText.Split('\n');

				var height = listBox.Font.Height;
				listBox.ItemHeight = height * lines.Length + height / 2;

				using (Brush brush = new SolidBrush(e.ForeColor))
				{
					int yOffset = e.Bounds.Top;
					foreach (string line in lines)
					{
						e.Graphics.DrawString(line, e.Font, brush, e.Bounds.Left, yOffset);
						yOffset += e.Font.Height;
					}
				}
			}
			e.DrawFocusRectangle();
		}

		public static void ApplyFontToAllControls(Form form, Font font)
		{
			form.Font = font;
			ApplyFontToControls(form.Controls);

			void ApplyFontToControls(Control.ControlCollection controls)
			{
				foreach (Control control in controls)
				{
					control.Font = font;
					ApplyFontToControls(control.Controls);
				}
			}
		}
	}
}
