using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisGeek.Apps.OfficeLineArt.Model {
	/// <summary>多角形のコレクション
	/// </summary>
	public class PolygonCollection : CollectionBase<Polygon> {
		// コンストラクター
		internal PolygonCollection(Field field, int apexCount, int count) {
			this.Field = field;

			// 多角形を作成する。
			this.items =
				Enumerable
					.Range(0, count)
					.Select(idx => new Polygon(field, apexCount))
					.ToArray();
		}

		// フィールド
		private readonly IReadOnlyList<Polygon> items;

		// インデクサー
		public Polygon this[int index] {
			get {
				return this.items[index];
			}
		}

		// プロパティ
		public Field Field { get; }

		public int Count {
			get {
				return this.items.Count;
			}
		}

		// メソッド
		public override IEnumerator<Polygon> GetEnumerator() {
			return items.GetEnumerator();
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
	}
}
