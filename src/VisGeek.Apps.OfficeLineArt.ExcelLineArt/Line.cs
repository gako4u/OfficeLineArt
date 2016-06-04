using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;

namespace VisGeek.Apps.OfficeLineArt.ExcelLineArt {
	internal class Line : OfficeLineArt.Line {
		// コンストラクター
		internal Line(Polygon parent, Apex begin, Apex end) : base(parent, begin, end) {
			this.Field = (Field)parent.Polygons.Field;
			this.shape = this.CreateShape();
		}

		// フィールド
		private Excel.Shape shape;

		public Field Field { get; }

		// インデクサー

		// プロパティ

		// イベントハンドラー
		protected override void RefrectFromBegin() {
			// End の方にまかせる。
		}

		protected override void RefrectFromEnd() {
			this.shape.Delete();
			this.shape = this.CreateShape();
		}

		// メソッド
		private Excel.Shape CreateShape() {
			var shapes = this.Field.Cell.Worksheet.Shapes;
			var result = shapes.AddLine(this.Begin.X.FloatValue, this.Begin.Y.FloatValue, this.End.X.FloatValue, this.End.Y.FloatValue);
			result.Line.ForeColor.SetRgb(this.Color);
			result.Line.Transparency = (float)this.Transparency;
			return result;
		}

		// スタティックコンストラクター

		// スタティックフィールド

		// スタティックプロパティ

		// スタティックメソッド
	}
}
