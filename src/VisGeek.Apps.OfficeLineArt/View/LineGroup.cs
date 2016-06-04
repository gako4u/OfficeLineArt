using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using VisGeek.Apps.OfficeLineArt.Model;

namespace VisGeek.Apps.OfficeLineArt.View {
	/// <summary>多角形を構成する線のコレクション
	/// </summary>
	public class LineGroup : CollectionBase<Line> {
		// コンストラクター
		internal LineGroup(LineGroupCollection parent, Polygon polygon, double transparency) {
			this.Parent = parent;
			this.Transparency = transparency;

			using (var e = polygon.Apexes.GetEnumerator()) {
				var lineList = new List<Line>(polygon.Apexes.Count);

				// 直線シェイプを作成する。
				if (e.MoveNext()) {
					Apex first = e.Current;

					Apex prev = e.Current;
					while (e.MoveNext()) {
						Apex current = e.Current;
						var line = parent.Parent.CreateLine(this, prev, current);
						lineList.Add(line);
						prev = current;
					}

					{
						var line = parent.Parent.CreateLine(this, prev, first);
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
		public LineGroupCollection Parent { get; }

		public int Count {
			get {
				return this.lines.Length;
			}
		}

		public double Transparency { get; }

		// イベントハンドラー

		// メソッド
		public override IEnumerator<Line> GetEnumerator() {
			return this.lines.Cast<Line>().GetEnumerator();
		}

		public override string ToString() {
			return this.Select(line => line.ToString()).ToString(Environment.NewLine);
		}

		internal void Draw(Rectangle screen) {
			this.ForEach(line => line.Draw(screen));
		}
	}
}
