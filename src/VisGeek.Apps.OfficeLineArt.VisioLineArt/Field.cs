using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Visio;
using Visio = Microsoft.Office.Interop.Visio;
using VisGeek.Apps.OfficeLineArt.Model;
using VisGeek.Apps.OfficeLineArt.View;

namespace VisGeek.Apps.OfficeLineArt.VisioLineArt {
	internal class Field : OfficeLineArt.View.Field {

		// コンストラクター
		internal Field(OfficeLineArt.LineArt lineArt, Model.Field fieldModel, Color color)
			: base(lineArt, fieldModel, color) {

			this.Visio = ((LineArt)lineArt).Application;
			this.Page = this.Visio.Documents.Add("").Pages[1];

			this.Visio.BeforeWindowClosed += this.Visio_BeforeWindowClosed;
			this.Page.Document.BeforeDocumentClose += Document_BeforeDocumentClose;
			this.Page.BeforePageDelete += Page_BeforePageDelete;
		}

		// プロパティ
		public Application Visio { get; }

		public Page Page { get; }

		// イベントハンドラー
		private void Visio_BeforeWindowClosed(Window Window) {
			this.Disable();
		}

		private void Document_BeforeDocumentClose(Document doc) {
			this.Disable();
		}

		private void Page_BeforePageDelete(Page Page) {
			this.Disable();
		}


		// メソッド
		protected override void DisposeInternal() {
			this.Visio.BeforeWindowClosed -= this.Visio_BeforeWindowClosed;
			this.Page.Document.BeforeDocumentClose -= this.Document_BeforeDocumentClose;
			this.Page.BeforePageDelete -= this.Page_BeforePageDelete;
		}

		protected override OfficeLineArt.View.Line CreateLine(LineGroup polygon, Apex begin, Apex end) {
			return new Line(polygon, begin, end);
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
