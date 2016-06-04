using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using VisGeek.Apps.OfficeLineArt.Model;
using VisGeek.Apps.OfficeLineArt.View;

namespace VisGeek.Apps.OfficeLineArt.ExcelLineArt {
	internal class Field : OfficeLineArt.View.Field {
		// コンストラクター
		internal Field(OfficeLineArt.LineArt lineArt, Model.Field fieldModel, Color color) : base(lineArt, fieldModel, color) {
			this.Excel = ((LineArt)lineArt).Application;

			var wb = this.Excel.Workbooks.Add();
			Worksheet ws = wb.Worksheets[1];
			this.Cell = ws.Cells[1, "A"];
			this.Cell.RowHeight *= 25;
			this.Cell.ColumnWidth *= 10;
		}

		// フィールド
		private System.Action disableFiledMethod;

		// プロパティ
		public Application Excel { get; }

		public Range Cell { get; }

		// メソッド
		protected override void SetFieldDisabledHandler(System.Action disableFiledMethod) {
			this.disableFiledMethod = disableFiledMethod;

			this.Excel.WorkbookBeforeClose += this.Excel_WorkbookBeforeClose;
			this.Excel.SheetBeforeDelete += this.Excel_SheetBeforeDelete;
			this.Cell.Worksheet.BeforeDelete += () => disableFiledMethod();
		}

		private void Excel_SheetBeforeDelete(object Sh) {
			if (Sh is Worksheet) {
				if ((Worksheet)Sh == this.Cell.Worksheet) {
					this.disableFiledMethod();
				}
			}
		}

		private void Excel_WorkbookBeforeClose(Workbook Wb, ref bool Cancel) {
			this.disableFiledMethod();
		}

		protected override OfficeLineArt.View.Line CreateLine(LineGroup polygon, Apex begin, Apex end) {
			return new Line(polygon, begin, end);
		}

		protected override void GetRectanglePosition(out double beginX, out double beginY, out double endX, out double endY) {
			double width = this.Cell.Width;
			double height = this.Cell.Height;

			beginX = this.Cell.Left;
			beginY = this.Cell.Top;

			endX = beginX + width;
			endY = beginY + height;
		}
	}
}
