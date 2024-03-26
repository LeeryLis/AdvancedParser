using AdvancedParser.Forms;
using OfficeOpenXml;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AdvancedParser.Excel
{
	public static class ExcelSaver
	{
		public static void SaveToExcel(Header[] headers, string[,] data, int leftOffset = 0, int topOffset = 0, string caller = "")
		{
			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
			using (var package = new ExcelPackage())
			{
				var worksheet = package.Workbook.Worksheets.Add("Sheet1");

				CreateStyles(package);

				WrightData(worksheet, headers, data, leftOffset, topOffset);

				DrawBorders(worksheet, headers, data, leftOffset, topOffset);

				SaveFile(package, caller);
			}
		}

		internal static class ExcelStyle
		{
			internal static string Hyperlink = "HyperlinkStyle";
			internal static string Header = "HeaderStyle";
			internal static string Common = "CommonStyle";
		}

		private static void CreateStyles(ExcelPackage package)
		{
			var hyperlinkStyle = package.Workbook.Styles.CreateNamedStyle(ExcelStyle.Hyperlink);
			hyperlinkStyle.Style.Font.Size = 12;
			hyperlinkStyle.Style.Font.UnderLine = true;
			hyperlinkStyle.Style.Font.Color.SetColor(Color.Blue);

			var headerStyle = package.Workbook.Styles.CreateNamedStyle(ExcelStyle.Header);
			headerStyle.Style.Font.Size = 16;
			headerStyle.Style.Font.Bold = true;

			var commonStyle = package.Workbook.Styles.CreateNamedStyle(ExcelStyle.Common);
			commonStyle.Style.Font.Size = 12;
		}

		private static void WrightData(ExcelWorksheet worksheet, Header[] headers, string[,] data, int leftOffset = 0, int topOffset = 0)
		{
			// Запись заголовков
			for (int i = 0; i < headers.Length; i++)
			{
				worksheet.Column(i + 1 + leftOffset).Width = headers[i].Width;
				worksheet.Cells[1 + topOffset, i + 1 + leftOffset].Value = headers[i].Text;
				worksheet.Cells[1 + topOffset, i + 1 + leftOffset].StyleName = ExcelStyle.Header;
			}

			// Запись данных
			for (int row = 0; row < data.GetLength(0); row++)
			{
				for (int col = 0; col < data.GetLength(1); col++)
				{
					worksheet.Cells[row + 2 + topOffset, col + 1 + leftOffset].Value = data[row, col];

					if (headers[col].HasHyperlink)
					{
						worksheet.Cells[row + 2 + topOffset, col + 1 + leftOffset].Hyperlink = new Uri(data[row, col]);
						worksheet.Cells[row + 2 + topOffset, col + 1 + leftOffset].StyleName = ExcelStyle.Hyperlink;
					}
					else
					{
						worksheet.Cells[row + 2 + topOffset, col + 1 + leftOffset].StyleName = ExcelStyle.Common;
					}
				}
			}
		}

		private static void DrawBorders(ExcelWorksheet worksheet, Header[] headers, string[,] data, int leftOffset = 0, int topOffset = 0)
		{
			var dataLength = data.GetLength(0);

			ExcelRange headerCells = worksheet.Cells[
				1 + topOffset,
				1 + leftOffset,
				1 + topOffset,
				1 + leftOffset + (headers.Length - 1)
				];

			ExcelRange dataCells = worksheet.Cells[
				2 + topOffset,
				1 + leftOffset,
				2 + topOffset + (dataLength - 1),
				1 + leftOffset + (headers.Length - 1)
				];

			ExcelRange[] dataCellsByColumn = new ExcelRange[headers.Length];
			for (int i = 0; i < headers.Length; i++)
			{
				ExcelRange cells = worksheet.Cells[
					1 + topOffset,
					1 + leftOffset + i,
					2 + topOffset + (dataLength - 1),
					1 + leftOffset + i
					];
				dataCellsByColumn[i] = cells;
			}

			foreach (var column in dataCellsByColumn)
			{
				column.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
			}

			headerCells.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thick);
			dataCells.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thick);
		}

		private static void SaveFile(ExcelPackage package, string caller = "")
		{
			using (SaveFileDialog saveFileDialog = new SaveFileDialog())
			{
				saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
				saveFileDialog.Title = "Saving Result";
				saveFileDialog.FileName = $"result {caller} {DateTime.Now:yyyy.MM.dd-HH.mm.ss}";
				saveFileDialog.FilterIndex = 1;
				saveFileDialog.RestoreDirectory = true;

				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					string filePath = saveFileDialog.FileName;
					try
					{
						using (var fileStream = new FileStream(filePath, FileMode.Create))
						{
							package.SaveAs(fileStream);

							MessageManager.Show("Файл Excel сохранен успешно.");
						}
					}
					catch (IOException ex)
					{
						MessageManager.Show($"Ошибка сохранения файла: {ex.Message}");
					}
				}
			}
		}
	}
}
