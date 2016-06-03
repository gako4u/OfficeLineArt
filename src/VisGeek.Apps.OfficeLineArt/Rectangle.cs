﻿using System;
using System.Diagnostics;

namespace VisGeek.Apps.OfficeLineArt {
	/// <summary>座標を表す長方形
	/// </summary>
	public struct Rectangle {
		// コンストラクター
		public Rectangle(double beginX, double beginY, double endX, double endY) {
			this.Begin = new Point(beginX, beginY);
			this.End = new Point(endX, endY);
		}

		// フィールド

		// インデクサー

		// プロパティ
		public Point Begin { get; }

		public Point End { get; }

		// イベントハンドラー

		// メソッド

		// スタティックコンストラクター

		// スタティックフィールド

		// スタティックプロパティ

		// スタティックメソッド
	}
}
