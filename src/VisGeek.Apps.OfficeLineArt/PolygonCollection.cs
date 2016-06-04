using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisGeek.Apps.OfficeLineArt {
	/// <summary>多角形のコレクション
	/// </summary>
	public class PolygonCollection : CollectionBase<Polygon> {
		// コンストラクター
		internal PolygonCollection(Field field, int apexCount, int count, Color color) {
			this.Field = field;

			// 多角形を作成する。
			this.items =
				Enumerable
					.Range(0, count)
					.Reverse()
					.Select(idx => new Polygon(this, apexCount, color, this.GetTransparency(idx, count)))
					.Reverse()
					.ToArray();

			// 選択状態を解除する。
			field.DelselectAll();
		}

		// フィールド
		private readonly Polygon[] items;

		// インデクサー

		// プロパティ
		public Field Field { get; }

		public LineArt LineArt {
			get {
				return this.Field.LineArt;
			}
		}

		// イベントハンドラー

		// メソッド
		public override IEnumerator<Polygon> GetEnumerator() {
			return items.Select(item => item).GetEnumerator();
		}

		internal void Move() {
			using (var e = this.Reverse().GetEnumerator()) {
				if (e.MoveNext()) {
					Polygon prev = e.Current;

					while (e.MoveNext()) {
						Polygon current = e.Current;
						prev.MoveTo(current);
						prev = current;
					}
				}
			}

			this.FirstOrDefault()?.Move();
		}

		internal void RefrectPositions() {
			this.Reverse().ForEach(polygon => polygon.Lines.RefrectPositions());
		}

		private double GetTransparency(int idx, int count) {
			double result = Math.Max(0.0, 1.0 / count * idx);
			return result;
		}

		// スタティックコンストラクター

		// スタティックフィールド

		// スタティックプロパティ

		// スタティックメソッド
	}
}
