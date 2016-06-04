using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using VisGeek.Apps.OfficeLineArt.View;

namespace VisGeek.Apps.OfficeLineArt.Model {
	/// <summary>多角形
	/// </summary>
	public class Polygon {
		// コンストラクター
		internal Polygon(Field field, int apexCount) {
			this.Field = field;
			this.Apexes = new ApexCollection(this, apexCount);
		}

		// フィールド

		// インデクサー

		// プロパティ
		public Field Field { get; }

		public ApexCollection Apexes { get; }

		// イベントハンドラー

		// メソッド
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
	}
}
