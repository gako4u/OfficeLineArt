using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Forms = System.Windows.Forms;
using Office = Microsoft.Office.Interop.Visio;

namespace VisGeek.Apps.OfficeLineArt.VisioLineArt {
	internal class LineArt : OfficeLineArt.LineArt {
		// コンストラクター
		internal LineArt(Office.Application application) : base() {
			this.Application = application;
		}

		// フィールド
		private readonly Dispatcher dispatcher = Dispatcher.CurrentDispatcher;

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

		protected override T Invoke<T>(Func<T> action) {
			var invokeResult = this.dispatcher.BeginInvoke(action);
			invokeResult.Wait();
			return (T)invokeResult.Result;
		}
	}
}
