using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Office = Microsoft.Office.Interop.Excel;
using Forms = System.Windows.Forms;

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

		protected override OfficeLineArt.Field CreateField(OfficeLineArt.LineArt lineArt, int apexCount, int afterImageCount) {
			return new Field(this, apexCount, afterImageCount);
		}

		// スタティックコンストラクター

		// スタティックフィールド

		// スタティックプロパティ

		// スタティックメソッド
	}
}
