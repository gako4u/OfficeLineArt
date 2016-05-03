using System;
using System.Diagnostics;

namespace VisGeek.Apps.OfficeLineArt {
	public class Rectangle {
		// コンストラクター
		public Rectangle(Field field, double beginLeft, double beginTop, double endLeft, double endTop) {
			this.LeftTop = new Point(beginLeft, beginTop);
			this.RightBottom = new Point(endLeft, endTop);

			//Debug.WriteLine("Filed Width:{0}", this.Width);
			//Debug.WriteLine("Filed Height:{0}", this.Height);
		}

		// フィールド
		public Field Field { get; }

		// インデクサー

		// プロパティ
		public Point LeftTop { get; }

		public Point RightBottom { get; }

		// イベントハンドラー

		// メソッド

		// スタティックコンストラクター

		// スタティックフィールド

		// スタティックプロパティ

		// スタティックメソッド
	}
}
