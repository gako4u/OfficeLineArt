using Microsoft.Office.Interop.Visio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gako.Apps.OfficeLineArt.VisioLineArt {
	internal class Line : OfficeLineArt.Line {
		// コンストラクター
		internal Line(LineCollection lines, Apex begin, Apex end, Field field) : base(lines, begin, end) {
			this.shape = field.Page.DrawLine(begin.Left.Value, begin.Top.Value, end.Left.Value, end.Top.Value);
			var cell = this.shape.GetCellSRC(VisSectionIndices.visSectionObject, VisRowIndices.visRowLine, VisCellIndices.visLineColor);

			var color = lines.Polygon.Color;
			cell.FormulaU = string.Format("THEMEGUARD(RGB({0},{1},{2}))", color.R, color.G, color.B);
		}

		// フィールド
		private readonly Shape shape;

		// インデクサー

		// プロパティ

		// イベントハンドラー
		protected override void RefrectFromBegin() {
			this.shape.SetBegin(this.Begin.Left.Value, this.Begin.Top.Value);
		}

		protected override void RefrectFromEnd() {
			this.shape.SetEnd(this.End.Left.Value, this.End.Top.Value);
		}

		protected override void BringToFront() {
			this.shape.BringToFront();
		}

		// メソッド

		// スタティックコンストラクター

		// スタティックフィールド

		// スタティックプロパティ

		// スタティックメソッド
	}
}
