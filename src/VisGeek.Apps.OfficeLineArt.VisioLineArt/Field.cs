using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Visio;
using Visio = Microsoft.Office.Interop.Visio;

namespace VisGeek.Apps.OfficeLineArt.VisioLineArt {
	internal class Field : OfficeLineArt.Field {
		// コンストラクター
		internal Field(OfficeLineArt.LineArt lineArt, int apexCount, int afterImageCount) : base(lineArt, apexCount, afterImageCount) {
			this.Visio = ((LineArt)lineArt).Application;
			this.Page = this.Visio.Documents.Add("").Pages[1];
		}

		// フィールド

		// インデクサー

		// プロパティ
		public Application Visio { get; }

		public Page Page { get; }

		// イベントハンドラー

		// メソッド
		protected override void SetFieldDisabledHandler(Action disableFiledMethod) {
			this.Visio.BeforeWindowClosed += v => disableFiledMethod();
			this.Page.Document.BeforeDocumentClose += d => disableFiledMethod();
			this.Page.BeforePageDelete += p => disableFiledMethod();
		}

		protected override void DelselectAll() {
			this.Page.Application.ActiveWindow.DeselectAll();
		}

		protected override OfficeLineArt.Line CreateLine(Polygon polygon, Apex begin, Apex end) {
			return new Line(polygon, begin, end, this);
		}

		protected override void GetRectanglePosition(out double beginX, out double beginY, out double endX, out double endY) {
			double width = this.GetSideLength(VisCellIndices.visPageWidth);
			double height = this.GetSideLength(VisCellIndices.visPageHeight);

			beginX = 0;
			beginY = 0;

			endX = beginX + width;
			endY = beginY + height;
		}

		private double GetSideLength(VisCellIndices cellIndex) {
			var cell = this.Page.PageSheet.GetCellSRC(VisSectionIndices.visSectionObject, VisRowIndices.visRowPage, cellIndex);
			double result = cell.Result[VisUnitCodes.visNumber];
			return result;
		}
	}
}
