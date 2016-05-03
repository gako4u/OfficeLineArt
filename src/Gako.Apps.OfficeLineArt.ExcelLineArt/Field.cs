﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace Gako.Apps.OfficeLineArt.ExcelLineArt {
	internal class Field : OfficeLineArt.Field {
		// コンストラクター
		internal Field(LineArt lineArt, int apexCount, int afterImageCount) : base(lineArt, apexCount, afterImageCount) {
			this.Excel = ((ExcelLineArt)lineArt).Excel;

			var wb = this.Excel.Workbooks.Add();
			Worksheet ws = wb.Worksheets[1];
			this.Cell = ws.Cells[2, "A"];
		}

		// フィールド
		private System.Action disableFiledMethod;

		// インデクサー

		// プロパティ
		public Application Excel { get; }

		public Range Cell { get; }

		// イベントハンドラー

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

		protected override void DelselectAll() {
			this.Cell.Select();
		}

		protected override OfficeLineArt.Line CreateLine(LineCollection lines, Apex begin, Apex end) {
			return new Line(lines, begin, end);
		}

		protected override void GetRectanglePosition(out double beginLeft, out double beginTop, out double endLeft, out double endTop) {
			double width = this.Cell.Width;
			double height = this.Cell.Height;

			beginLeft = this.Cell.Left;
			beginTop = this.Cell.Top;

			endLeft = beginLeft + width;
			endTop = beginTop + height;
		}

		// スタティックコンストラクター

		// スタティックフィールド

		// スタティックプロパティ

		// スタティックメソッド
	}
}