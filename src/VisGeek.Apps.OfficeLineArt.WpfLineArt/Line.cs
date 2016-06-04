using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using VisGeek.Apps.OfficeLineArt.Model;
using VisGeek.Apps.OfficeLineArt.View;

namespace VisGeek.Apps.OfficeLineArt.WpfLineArt {
	internal class Line : OfficeLineArt.View.Line {
		// コンストラクター
		internal Line(LineGroup parent, Apex begin, Apex end) : base(parent, begin, end) {
		}

		// フィールド
		private System.Windows.Shapes.Line shape = null;

		// プロパティ
		public new Field Field {
			get {
				return (Field)base.Field;
			}
		}

		// イベントハンドラー
		protected override void Draw(double beginX, double beginY, double endX, double endY) {
			if (this.shape == null) {
				this.shape = new System.Windows.Shapes.Line();
				this.shape.Stroke = new SolidColorBrush(this.CreateColor());
				this.Field.Canvas.Children.Add(this.shape);
			}

			this.shape.X1 = beginX;
			this.shape.Y1 = beginY;
			this.shape.X2 = endX;
			this.shape.Y2 = endY;
		}

		// メソッド
		private System.Windows.Media.Color CreateColor() {
			byte a = (byte)(255 - (this.Transparency * 255));
			byte r = this.Color.R;
			byte g = this.Color.G;
			byte b = this.Color.B;
			return System.Windows.Media.Color.FromArgb(a, r, g, b);
		}
	}
}
