using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace VisGeek.Apps.OfficeLineArt.WpfLineArt {
	internal class Line : OfficeLineArt.Line {
		// コンストラクター
		internal Line(LineCollection lines, Apex begin, Apex end, Field field) : base(lines, begin, end) {
			var beginPoint = new System.Windows.Point(begin.X.Value, begin.Y.Value);
			var endPoint = new System.Windows.Point(end.X.Value, end.Y.Value);
			this.shape = new System.Windows.Shapes.Line();
			this.shape.Stroke = new SolidColorBrush(this.CreateColor(lines.Polygon.Color));
			field.Canvas.Children.Add(this.shape);
		}

		// フィールド
		private readonly System.Windows.Shapes.Line shape;

		// インデクサー

		// プロパティ

		// イベントハンドラー
		protected override void RefrectFromBegin() {
			this.shape.X1 = this.Begin.X.Value;
			this.shape.Y1 = this.Begin.Y.Value;
		}

		protected override void RefrectFromEnd() {
			this.shape.X2 = this.End.X.Value;
			this.shape.Y2 = this.End.Y.Value;
		}

		// メソッド
		private System.Windows.Media.Color CreateColor(Color color) {
			byte r = color.R;
			byte g = color.G;
			byte b = color.B;
			return System.Windows.Media.Color.FromRgb(r, g, b);
		}

		// スタティックコンストラクター

		// スタティックフィールド

		// スタティックプロパティ

		// スタティックメソッド
	}
}
