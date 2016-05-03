using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace VisGeek.Apps.OfficeLineArt.ExcelLineArt {
	public static class ExtensionsMethods {
		public static void SetColor(this Excel.ColorFormat colorFormat, Color color) {
			colorFormat.RGB = ExtensionsMethods.ToRGB(color);
		}

		public static int ToRGB(this Color color) {
			int result = 0;
			result += color.R * 1;
			result += color.G * 256;
			result += color.B * 256 * 256;
			return result;
		}
	}
}
