using Microsoft.Office.Interop.Visio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisGeek.Apps.OfficeLineArt.VisioLineArt {
	internal class Line : OfficeLineArt.Line {
		// コンストラクター
		internal Line(LineCollection lines, Apex begin, Apex end, Field field) : base(lines, begin, end) {
			this.shape = field.Page.DrawLine(begin.X.Value, begin.Y.Value, end.X.Value, end.Y.Value);
			var cell = this.shape.GetCellSRC(VisSectionIndices.visSectionObject, VisRowIndices.visRowLine, VisCellIndices.visLineColor);

			var color = lines.Polygon.Color;
			cell.FormulaU = string.Format("THEMEGUARD(RGB({0},{1},{2}))", color.R, color.G, color.B);

			// 透過度
			double transparency = color.Transparency;
			string transparencyPercentage = string.Format("{0}%", transparency * 100);
			this.shape.GetCellSRC(VisSectionIndices.visSectionObject, VisRowIndices.visRowLine, VisCellIndices.visLineColorTrans).FormulaU = transparencyPercentage;
			this.shape.GetCellSRC(VisSectionIndices.visSectionObject, VisRowIndices.visRowGradientProperties, VisCellIndices.visLineGradientEnabled).FormulaU = "FALSE";
		}

		// フィールド
		private readonly Shape shape;

		// インデクサー

		// プロパティ

		// イベントハンドラー
		protected override void RefrectFromBegin() {
			this.shape.SetBegin(this.Begin.X.Value, this.Begin.Y.Value);
		}

		protected override void RefrectFromEnd() {
			this.shape.SetEnd(this.End.X.Value, this.End.Y.Value);
		}

		// メソッド

		// スタティックコンストラクター

		// スタティックフィールド

		// スタティックプロパティ

		// スタティックメソッド
	}
}
