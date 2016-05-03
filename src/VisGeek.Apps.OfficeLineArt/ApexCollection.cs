using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections;
using System.Diagnostics;

namespace VisGeek.Apps.OfficeLineArt {
	public class ApexCollection : IEnumerable<Apex> {
		// コンストラクター
		internal ApexCollection(Polygon polygon, int apexCount) {
			this.Polygon = polygon;
			this.items = Enumerable.Range(0, apexCount).Select(i => new Apex(this.Polygon)).ToArray();
		}

		// フィールド
		private readonly Apex[] items;

		// インデクサー
		public Apex this[int index] {
			get {
				return this.items[index];
			}
		}

		// プロパティ
		private Polygon Polygon { get; }

		public int Count {
			get {
				return items.Length;
			}
		}

		// イベントハンドラー

		// メソッド
		public IEnumerator<Apex> GetEnumerator() {
			return this.items.Cast<Apex>().GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return this.GetEnumerator();
		}

		// スタティックコンストラクター

		// スタティックフィールド

		// スタティックプロパティ

		// スタティックメソッド

	}
}