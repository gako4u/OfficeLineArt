using System;
using System.Diagnostics;
using System.Linq;


namespace VisGeek.Apps.OfficeLineArt.Model {
	/// <summary>ラインアートを描画するフィールド
	/// </summary>
	public class Field {
		// コンストラクター
		internal Field(LineArt lineArt, double width, double height, int apexCount, int afterImageCount) {
			this.LineArt = lineArt;
			this.Width = width;
			this.Height = height;
			this.Polygons = new PolygonCollection(this, apexCount, afterImageCount + 1);
		}

		// プロパティ
		public LineArt LineArt { get; }

		public double Width { get; }

		public double Height { get; }

		public PolygonCollection Polygons { get; }

		// メソッド
	}
}
