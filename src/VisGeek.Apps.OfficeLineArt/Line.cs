using Gako.Collections.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Collections;

namespace Gako.Apps.OfficeLineArt {
	public abstract class Line {
		// コンストラクター
		protected Line(LineCollection lines, Apex begin, Apex end) {
			this.Lines = lines;
			this.Begin = begin;
			this.End = end;
		}


		// フィールド

		// インデクサー

		// プロパティ
		public LineCollection Lines { get; }

		public Apex Begin { get; }

		public Apex End { get; }

		// イベントハンドラー
		protected internal abstract void RefrectFromBegin();

		protected internal abstract void RefrectFromEnd();

		protected internal abstract void BringToFront();

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
