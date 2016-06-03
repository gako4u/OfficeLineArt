using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VisGeek.Apps.OfficeLineArt.WpfLineArt {
	internal class Field : OfficeLineArt.Field {
		// コンストラクター
		internal Field(OfficeLineArt.LineArt lineArt, int apexCount, int afterImageCount) : base(lineArt, apexCount, afterImageCount) {
			this.MainWindow = ((LineArt)lineArt).MainWindow;
			this.Canvas = ((LineArt)lineArt).Canvas;
		}

		// フィールド

		// インデクサー

		// プロパティ
		public MainWindow MainWindow { get; }

		public Canvas Canvas { get; }

		// イベントハンドラー

		// メソッド
		protected override void SetFieldDisabledHandler(Action disableFiledMethod) {
			this.MainWindow.Closing += (s, e) => disableFiledMethod();
		}

		protected override void DelselectAll() {
		}

		protected override OfficeLineArt.Line CreateLine(LineCollection lines, Apex begin, Apex end) {
			return new Line(lines, begin, end, this);
		}

		protected override void GetRectanglePosition(out double beginX, out double beginY, out double endX, out double endY) {
			double width = this.Canvas.ActualWidth;
			double height = this.Canvas.ActualHeight;

			beginX = 0;
			beginY = 0;

			endX = beginX + width;
			endY = beginY + height;
		}

		// スタティックコンストラクター

		// スタティックフィールド

		// スタティックプロパティ

		// スタティックメソッド
	}
}
