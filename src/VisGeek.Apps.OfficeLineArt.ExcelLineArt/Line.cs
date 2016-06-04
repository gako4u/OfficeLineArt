using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;
using VisGeek.Apps.OfficeLineArt.Model;
using VisGeek.Apps.OfficeLineArt.View;

namespace VisGeek.Apps.OfficeLineArt.ExcelLineArt {
	internal class Line : OfficeLineArt.View.Line {
		// コンストラクター
		internal Line(LineGroup parent, Apex begin, Apex end) : base(parent, begin, end) {
		}

		// フィールド
		private Excel.Shape shape = null;

		// プロパティ
		public new Field Field {
			get {
				return (Field)base.Field;
			}
		}

		// イベントハンドラー
		protected override void Draw(double beginX, double beginY, double endX, double endY) {
			this.shape?.Delete();

			var shapes = this.Field.Cell.Worksheet.Shapes;
			this.shape = shapes.AddLine((float)beginX, (float)beginY, (float)endX, (float)endY);
			this.shape.Line.ForeColor.SetRgb(this.Parent.Parent.Color);
			this.shape.Line.Transparency = (float)this.Parent.Transparency;
		}
	}
}
