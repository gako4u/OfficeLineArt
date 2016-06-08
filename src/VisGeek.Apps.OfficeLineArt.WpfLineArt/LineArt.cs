using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VisGeek.Apps.OfficeLineArt.WpfLineArt {
	internal class LineArt : OfficeLineArt.Ribbon.LineArt {
		// コンストラクター
		internal LineArt(MainWindow mainWindow, Canvas canvas) : base(mainWindow.Dispatcher) {
			this.MainWindow = mainWindow;
			this.Canvas = canvas;
		}

		// プロパティ
		public MainWindow MainWindow { get; }

		public Canvas Canvas { get; }

		// メソッド
		protected override View.Field CreateField(Model.Field fieldModel, Color color) {
			return new Field(this, fieldModel, color);
		}
	}
}
