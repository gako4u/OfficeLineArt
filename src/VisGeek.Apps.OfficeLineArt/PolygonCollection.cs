﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisGeek.Apps.OfficeLineArt {
	/// <summary>多角形のコレクション
	/// </summary>
	public class PolygonCollection : IEnumerable<Polygon> {
		// コンストラクター
		internal PolygonCollection(Field field, int apexCount, int count, Color color) {
			this.Field = field;

			// 多角形を作成する。
			this.items =
				Enumerable
					.Range(0, count)
					.Reverse()
					.Select(idx => new Polygon(this, apexCount, this.GetColor(color, idx, count)))
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
		public IEnumerator<Polygon> GetEnumerator() {
			return items.Select(item => item).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return this.GetEnumerator();
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

		private Color GetColor(Color initialColor, int idx, int count) {
			Color result = initialColor;

			switch (count) {
				case 1:
				default:
					byte a = (byte)Math.Max(0, result.A - (result.A / count * idx));
					byte r = result.R;
					byte g = result.G;
					byte b = result.B;
					result = new Color(a, r, g, b);
					break;
			}

			return result;
		}

		// スタティックコンストラクター

		// スタティックフィールド

		// スタティックプロパティ

		// スタティックメソッド
	}
}
