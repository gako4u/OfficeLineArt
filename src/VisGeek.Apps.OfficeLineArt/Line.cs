using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Collections;

namespace VisGeek.Apps.OfficeLineArt {
	/// <summary>多角形を構成する線
	/// </summary>
	public abstract class Line {
		// コンストラクター
		protected Line(Polygon parent, Apex begin, Apex end) {
			this.Parent = parent;
			this.Begin = begin;
			this.End = end;
		}

		// プロパティ
		public Polygon Parent { get; }

		public Apex Begin { get; }

		public Apex End { get; }

		public Color Color {
			get {
				return this.Parent.Color;
			}
		}

		public double Transparency {
			get {
				return this.Parent.Transparency;
			}
		}

		// イベントハンドラー
		protected internal abstract void RefrectFromBegin();

		protected internal abstract void RefrectFromEnd();

		// メソッド
		public override string ToString() {
			return string.Format("Begin:{2} End:{1}", this.Begin, this.End);
		}

		// スタティックコンストラクター

		// スタティックフィールド

		// スタティックプロパティ

		// スタティックメソッド
	}
}
