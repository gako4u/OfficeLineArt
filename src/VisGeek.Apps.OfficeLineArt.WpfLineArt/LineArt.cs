using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VisGeek.Apps.OfficeLineArt.WpfLineArt {
	internal class LineArt : OfficeLineArt.LineArt {
		// コンストラクター
		internal LineArt(MainWindow mainWindow, Canvas canvas) : base() {
			this.MainWindow = mainWindow;
			this.Canvas = canvas;
		}

		// フィールド

		// インデクサー

		// プロパティ
		public MainWindow MainWindow { get; }

		public Canvas Canvas { get; }

		// イベントハンドラー

		// メソッド
		protected override void Draw() {
		}

		protected override void Sleep(TimeSpan timeSpan) {
			Thread.Sleep(timeSpan);
		}

		protected override OfficeLineArt.Field CreateField(OfficeLineArt.LineArt lineArt, int apexCount, int afterImageCount) {
			return new Field(this, apexCount, afterImageCount);
		}

		protected override T Invoke<T>(Func<T> action) {
			var invokeResult = this.MainWindow.Dispatcher.BeginInvoke(action);
			invokeResult.Wait();
			return (T)invokeResult.Result;
		}

		// スタティックコンストラクター

		// スタティックフィールド

		// スタティックプロパティ

		// スタティックメソッド
	}
}
