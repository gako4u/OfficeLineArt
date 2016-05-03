using Gako.Apps.OfficeLineArt;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Forms = System.Windows.Forms;

namespace Gako.Apps.OfficeLineArt.ExcelLineArt {
	internal class ExcelLineArt : LineArt {
		// コンストラクター
		internal ExcelLineArt(Excel.Application Excel) : base() {
			this.Excel = Excel;
		}

		// フィールド

		// インデクサー

		// プロパティ
		public Excel.Application Excel { get; }

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

		protected override OfficeLineArt.Field CreateField(LineArt lineArt, int apexCount, int afterImageCount) {
			return new Field(this, apexCount, afterImageCount);
		}

		// スタティックコンストラクター

		// スタティックフィールド

		// スタティックプロパティ

		// スタティックメソッド
	}
}
