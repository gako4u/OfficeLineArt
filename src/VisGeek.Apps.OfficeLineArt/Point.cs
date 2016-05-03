using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisGeek.Apps.OfficeLineArt {
	/// <summary>座標の位置
	/// </summary>
	public struct Point {
		// コンストラクター
		internal Point(double left, double top) {
			this.Left = left;
			this.Top = top;
		}

		// フィールド

		// インデクサー

		// プロパティ
		public double Left { get; }

		public double Top { get; }

		// イベントハンドラー

		// メソッド

		// スタティックコンストラクター

		// スタティックフィールド

		// スタティックプロパティ

		// スタティックメソッド
	}
}
