using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Drawing;

namespace VisGeek.Apps.OfficeLineArt {
	/// <summary>多角形
	/// </summary>
	public class Polygon {
		// コンストラクター
		internal Polygon(PoLygonCollection polygons, int apexCount, Color color) {
			this.Polygons = polygons;
			this.Color = color;
			this.Apexes = new ApexCollection(this, apexCount);
			this.Lines = new LineCollection(this, this.Apexes);
		}

		// フィールド

		// インデクサー

		// プロパティ
		public PoLygonCollection Polygons { get; }

		public LineCollection Lines { get; }

		public ApexCollection Apexes { get; }

		public Color Color { get; }

		// イベントハンドラー

		// メソッド
		internal void BringToFront() {
			this.Lines.BringToFront();
		}

		internal void Move() {
			this.Apexes.ForEach(apex => apex.Move());

			this.Apexes.Where((apex, index) => index == 0)
				.ForEach((apex, index) => Debug.WriteLine("{0}:{1} {2}:{3} {4}:{5}", nameof(Apex), index, nameof(apex.X), apex.X, nameof(apex.Y), apex.Y));
		}

		internal void MoveTo(Polygon other) {
			foreach (int i in Enumerable.Range(0, this.Apexes.Count)) {
				var myApex = this.Apexes[i];
				var otherApex = other.Apexes[i];

				myApex.MoveTo(otherApex);
			}
		}

		// スタティックコンストラクター

		// スタティックフィールド

		// スタティックプロパティ

		// スタティックメソッド
	}
}