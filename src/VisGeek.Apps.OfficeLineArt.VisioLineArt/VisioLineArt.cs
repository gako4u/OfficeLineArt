using Microsoft.Office.Interop.Visio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visio = Microsoft.Office.Interop.Visio;
using Forms = System.Windows.Forms;

namespace VisGeek.Apps.OfficeLineArt.VisioLineArt {
	internal class VisioLineArt : LineArt {
		// コンストラクター
		internal VisioLineArt(Visio.Application visio) : base() {
			this.Visio = visio;
		}

		// フィールド

		// インデクサー

		// プロパティ
		public Visio.Application Visio { get; }

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
