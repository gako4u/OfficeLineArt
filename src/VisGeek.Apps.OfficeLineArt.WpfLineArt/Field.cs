using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using VisGeek.Apps.OfficeLineArt.Model;
using VisGeek.Apps.OfficeLineArt.View;

namespace VisGeek.Apps.OfficeLineArt.WpfLineArt {
	internal class Field : OfficeLineArt.View.Field {
		// コンストラクター
		internal Field(OfficeLineArt.LineArt lineArt, Model.Field fieldModel, Color color)
			: base(lineArt, fieldModel, color) {

			this.MainWindow = ((LineArt)lineArt).MainWindow;
			this.Canvas = ((LineArt)lineArt).Canvas;
		}

		// プロパティ
		public MainWindow MainWindow { get; }

		public Canvas Canvas { get; }

		// メソッド
		protected override OfficeLineArt.View.Line CreateLine(LineGroup polygon, Apex begin, Apex end) {
			return new Line(polygon, begin, end);
		}

		protected override void GetRectanglePosition(out double beginX, out double beginY, out double endX, out double endY) {
			double width = this.Canvas.ActualWidth;
			double height = this.Canvas.ActualHeight;

			beginX = 0;
			beginY = 0;

			endX = beginX + width;
			endY = beginY + height;
		}
	}
}
