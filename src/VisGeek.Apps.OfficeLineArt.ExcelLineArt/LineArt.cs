using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Office = Microsoft.Office.Interop.Excel;
using Forms = System.Windows.Forms;
using VisGeek.Apps.OfficeLineArt.Model;
using VisGeek.Apps.OfficeLineArt.View;

namespace VisGeek.Apps.OfficeLineArt.ExcelLineArt {
	internal class LineArt : OfficeLineArt.LineArt {
		// コンストラクター
		internal LineArt(Office.Application application) : base() {
			this.Application = application;
		}

		// フィールド

		// インデクサー

		// プロパティ
		public Office.Application Application { get; }

		// イベントハンドラー

		// メソッド
		protected override void Draw() {
			Forms.Application.DoEvents();
		}

		protected override void Sleep(TimeSpan timeSpan) {
			var dateTime = DateTime.Now + timeSpan;
			while (DateTime.Now < dateTime) {
				Forms.Application.DoEvents();
			}
		}

		protected override View.Field CreateField(Model.Field fieldModel, Color color) {
			return new Field(this, fieldModel, color);
		}
	}
}
