using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Forms = System.Windows.Forms;
using Office = Microsoft.Office.Interop.Excel;

namespace VisGeek.Apps.OfficeLineArt.ExcelLineArt {
	internal class LineArt : OfficeLineArt.Ribbon.LineArt {
		// コンストラクター
		internal LineArt(Office.Application application) : base(Dispatcher.CurrentDispatcher) {
			this.Application = application;
		}

		// プロパティ
		public Office.Application Application { get; }

		// メソッド
		protected override View.Field CreateField(Model.Field fieldModel, Color color) {
			return new Field(this, fieldModel, color);
		}

		protected override void DoEvents() {
			Forms.Application.DoEvents();
		}
	}
}
