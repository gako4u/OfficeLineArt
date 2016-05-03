using Gako.Collections.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Gako.Apps.OfficeLineArt {
	public class LineCollection : IEnumerable<Line> {
		// コンストラクター
		internal LineCollection(Polygon polygon, ApexCollection apexes) {
			this.Polygon = polygon;

			using (var e = apexes.GetEnumerator()) {
				var lineList = new List<Line>(apexes.Count);

				// 直線シェイプを作成する。
				if (e.MoveNext()) {
					Apex first = e.Current;

					Apex prev = e.Current;
					while (e.MoveNext()) {
						Apex current = e.Current;
						var line = polygon.Polygons.Field.CreateLine(this, prev, current);
						lineList.Add(line);
						prev = current;
					}

					{
						var line = polygon.Polygons.Field.CreateLine(this, prev, first);
						lineList.Add(line);
					}
				}

				this.lines = lineList.ToArray();
			}
		}

		internal void BringToFront() {
			this.ForEach(line => line.BringToFront());
		}

		// フィールド
		private readonly Line[] lines;

		// インデクサー

		// プロパティ
		public Polygon Polygon { get; }

		public int Count {
			get {
				return this.lines.Length;
			}
		}

		// イベントハンドラー

		// メソッド
		public IEnumerator<Line> GetEnumerator() {
			return this.lines.Cast<Line>().GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return this.GetEnumerator();
		}

		public override string ToString() {
			return this.Select(line => line.ToString()).ToString(Environment.NewLine);
		}

		internal void RefrectPositions() {
			this.ForEach(line => line.RefrectFromBegin());
			this.ForEach(line => line.RefrectFromEnd());
		}

		// スタティックコンストラクター

		// スタティックフィールド

		// スタティックプロパティ

		// スタティックメソッド
	}
}
