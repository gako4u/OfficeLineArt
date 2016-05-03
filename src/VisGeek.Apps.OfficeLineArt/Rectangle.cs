using System;
using System.Diagnostics;

namespace VisGeek.Apps.OfficeLineArt {
	/// <summary>座標を表す長方形
	/// </summary>
	public class Rectangle {
		// コンストラクター
		public Rectangle(double beginLeft, double beginTop, double endLeft, double endTop) {
			this.LeftTop = new Point(beginLeft, beginTop);
			this.RightBottom = new Point(endLeft, endTop);
		}

		// フィールド

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
