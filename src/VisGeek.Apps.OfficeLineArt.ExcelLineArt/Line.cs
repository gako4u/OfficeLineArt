﻿using Microsoft.Office.Core;
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
		internal Line(LineCollection lines, Apex begin, Apex end) : base(lines, begin, end) {
			this.Field = ((Field)lines.Polygon.Polygons.Field);
			this.Color = lines.Polygon.Color;

			this.shape = this.createShape();
		}

		// フィールド
		private Excel.Shape shape;

		public Field Field { get; }

		public Color Color { get; }

		// インデクサー

		// プロパティ

		// イベントハンドラー
		protected override void RefrectFromBegin() {
			// End の方にまかせる。
		}

		protected override void RefrectFromEnd() {
			this.shape.Delete();
			this.shape = this.createShape();
		}

		// メソッド
		private Excel.Shape createShape() {
			var shapes = this.Field.Cell.Worksheet.Shapes;
			var result = shapes.AddLine((float)this.Begin.X.Value, (float)this.Begin.Y.Value, (float)this.End.X.Value, (float)this.End.Y.Value);
			result.Line.ForeColor.SetColor(this.Color);
			return result;
		}

		protected override void BringToFront() {
			this.shape.ZOrder(MsoZOrderCmd.msoBringToFront);
		}

		// スタティックコンストラクター

		// スタティックフィールド

		// スタティックプロパティ

		// スタティックメソッド
	}
}
