using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using VisGeek.Apps.OfficeLineArt.Model;

namespace VisGeek.Apps.OfficeLineArt.View {
	/// <summary>多角形
	/// </summary>
	public class LineGroupCollection : CollectionBase<LineGroup> {
		// コンストラクター
		public LineGroupCollection(Field parent, Color color, PolygonCollection polygons) {
			this.Parent = parent;
			this.Color = color;

			// 多角形を作成する。
			this.items =
				Enumerable
					.Range(0, polygons.Count)
					.Reverse()
					.Select(idx => new LineGroup(this, polygons[idx], this.GetTransparency(idx, polygons.Count)))
					.Reverse()
					.ToArray();
		}

		// フィールド
		private readonly IReadOnlyList<LineGroup> items;

		// インデクサー

		// プロパティ
		public Field Parent { get; }

		public Color Color { get; }

		// メソッド
		public override IEnumerator<LineGroup> GetEnumerator() {
			return this.items.GetEnumerator();
		}

		private double GetTransparency(int idx, int count) {
			double result = Math.Max(0.0, 1.0 / count * idx);
			return result;
		}
	}
}
