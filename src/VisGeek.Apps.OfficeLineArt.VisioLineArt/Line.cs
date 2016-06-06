using Microsoft.Office.Interop.Visio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisGeek.Apps.OfficeLineArt.Model;
using VisGeek.Apps.OfficeLineArt.View;

namespace VisGeek.Apps.OfficeLineArt.VisioLineArt {
	internal class Line : OfficeLineArt.View.Line {
		// コンストラクター
		internal Line(LineGroup parent, Apex begin, Apex end) : base(parent, begin, end) {
		}

		// フィールド
		private Shape shape = null;

		// プロパティ
		public new Field Field {
			get {
				return (Field)base.Field;
			}
		}

		// イベントハンドラー
		protected override void Draw(double beginX, double beginY, double endX, double endY) {
			if (this.shape == null) {
				// 直線シェイプを作成する。
				this.shape = this.Field.Page.DrawLine(beginX, beginY, endX, endY);

				// 色
				var cell = this.shape.GetCellSRC(VisSectionIndices.visSectionObject, VisRowIndices.visRowLine, VisCellIndices.visLineColor);
				cell.FormulaU = string.Format("THEMEGUARD(RGB({0},{1},{2}))", this.Color.R, this.Color.G, this.Color.B);

				// 透過度
				double transparency = this.Transparency;
				string transparencyPercentage = string.Format("{0}%", transparency * 100);
				this.shape.GetCellSRC(VisSectionIndices.visSectionObject, VisRowIndices.visRowLine, VisCellIndices.visLineColorTrans).FormulaU = transparencyPercentage;
				this.shape.GetCellSRC(VisSectionIndices.visSectionObject, VisRowIndices.visRowGradientProperties, VisCellIndices.visLineGradientEnabled).FormulaU = "FALSE";

				// 選択を解除する。
				this.shape.Application.ActiveWindow.DeselectAll();
			}

			this.shape.SetBegin(beginX, beginY);
			this.shape.SetEnd(endX, endY);
		}
	}
}
