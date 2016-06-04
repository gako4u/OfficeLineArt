using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace VisGeek.Apps.OfficeLineArt {
	/// <summary>多角形を構成する線のコレクション
	/// </summary>
	public class LineCollection : CollectionBase<Line> {
		// コンストラクター
		internal LineCollection(Polygon parent, ApexCollection apexes) {
			this.Parent = parent;

			using (var e = apexes.GetEnumerator()) {
				var lineList = new List<Line>(apexes.Count);

				// 直線シェイプを作成する。
				if (e.MoveNext()) {
					Apex first = e.Current;

					Apex prev = e.Current;
					while (e.MoveNext()) {
						Apex current = e.Current;
						var line = parent.Polygons.LineArt.Invoke(() => parent.Polygons.Field.CreateLine(parent, prev, current));
						lineList.Add(line);
						prev = current;
					}

					{
						var line = parent.Polygons.LineArt.Invoke(() => parent.Polygons.Field.CreateLine(parent, prev, first));
						lineList.Add(line);
					}
				}

				this.lines = lineList.ToArray();
			}
		}

		// フィールド
		private readonly Line[] lines;

		// インデクサー

		// プロパティ
		public Polygon Parent { get; }

		public int Count {
			get {
				return this.lines.Length;
			}
		}

		// イベントハンドラー

		// メソッド
		public override IEnumerator<Line> GetEnumerator() {
			return this.lines.Cast<Line>().GetEnumerator();
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
