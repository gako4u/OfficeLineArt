using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisGeek.Apps.OfficeLineArt.Ribbon;
using Visio = Microsoft.Office.Interop.Visio;

namespace VisGeek.Apps.OfficeLineArt.VisioLineArt {
	internal class RibbonDesigner : VisGeek.Apps.OfficeLineArt.Ribbon.RibbonDesigner {
		// コンストラクター
		public RibbonDesigner(RibbonBase ribbon)
			: base(ribbon, true) {
		}

		// イベントハンドラー
		private void Application_BeforeWindowClosed(Visio.Window Window) {
			if (this.Task != null && !this.Task.IsCompleted) {
				this.Task.Cancel();
				this.ApplicationClosed = true;
			}
		}

		private void Application_BeforePageDelete(Visio.Page Page) {
			if (this.Task != null && !this.Task.IsCompleted) {
				this.Task.Cancel();
				this.ApplicationClosed = true;
			}
		}

		// メソッド
		protected override OfficeLineArt.Ribbon.LineArt CreateLineArt() {
			var application = Globals.ThisAddIn.Application;
			application.BeforeWindowClosed += this.Application_BeforeWindowClosed;
			application.BeforePageDelete += this.Application_BeforePageDelete;

			return new VisioLineArt.LineArt(application);
		}
	}
}
