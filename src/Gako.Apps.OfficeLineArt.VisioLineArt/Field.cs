using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Visio;
using Visio = Microsoft.Office.Interop.Visio;

namespace Gako.Apps.OfficeLineArt.VisioLineArt {
	internal class Field : OfficeLineArt.Field {
		// コンストラクター
		internal Field(LineArt lineArt, int apexCount, int afterImageCount) : base(lineArt, apexCount, afterImageCount) {
			this.Visio = ((VisioLineArt)lineArt).Visio;
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

		protected override OfficeLineArt.Line CreateLine(LineCollection lines, Apex begin, Apex end) {
			return new Line(lines, begin, end, this);
		}

		protected override void GetRectanglePosition(out double beginLeft, out double beginTop, out double endLeft, out double endTop) {
			double width = this.GetSideLength(VisCellIndices.visPageWidth);
			double height = this.GetSideLength(VisCellIndices.visPageHeight);

			beginLeft = 0;
			beginTop = 0;

			endLeft = beginLeft + width;
			endTop = beginTop + height;
		}

		private double GetSideLength(VisCellIndices cellIndex) {
			var cell = this.Page.PageSheet.GetCellSRC(VisSectionIndices.visSectionObject, VisRowIndices.visRowPage, cellIndex);
			double result = cell.Result[VisUnitCodes.visNumber];
			return result;
		}

		// スタティックコンストラクター

		// スタティックフィールド

		// スタティックプロパティ

		// スタティックメソッド
	}
}
