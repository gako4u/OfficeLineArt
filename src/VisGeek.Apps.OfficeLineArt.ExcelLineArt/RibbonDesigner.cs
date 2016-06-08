using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisGeek.Apps.OfficeLineArt.Ribbon;
using Excel = Microsoft.Office.Interop.Excel;

namespace VisGeek.Apps.OfficeLineArt.ExcelLineArt {
	internal class RibbonDesigner : VisGeek.Apps.OfficeLineArt.Ribbon.RibbonDesigner {
		// コンストラクター
		public RibbonDesigner(RibbonBase ribbon)
			: base(ribbon, true) {
		}

		// イベントハンドラー
		private void Application_SheetBeforeDelete(object Sh) {
			if (this.Task != null && !this.Task.IsCompleted) {
				this.Task.Cancel();
				this.ApplicationClosed = true;
			}
		}

		private void Application_WorkbookBeforeClose(Excel.Workbook Wb, ref bool Cancel) {
			if (this.Task != null && !this.Task.IsCompleted) {
				this.Task.Cancel();
				this.ApplicationClosed = true;
			}
		}

		// メソッド
		protected override OfficeLineArt.Ribbon.LineArt CreateLineArt() {
			var application = Globals.ThisAddIn.Application;
			application.WorkbookBeforeClose += Application_WorkbookBeforeClose;
			application.SheetBeforeDelete += Application_SheetBeforeDelete;

			return new ExcelLineArt.LineArt(application);
		}
	}
}
