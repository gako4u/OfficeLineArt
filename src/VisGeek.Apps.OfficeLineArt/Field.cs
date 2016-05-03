using System;
using System.Diagnostics;
using System.Linq;


namespace Gako.Apps.OfficeLineArt {
	public abstract class Field {
		// コンストラクター
		protected Field(LineArt lineArt, int apexCount, int afterImageCount) {
			this.LineArt = lineArt;
			this.IsEnabled = true;
		}

		// フィールド

		// インデクサー

		// プロパティ
		public LineArt LineArt { get; }

		public bool IsEnabled { get; private set; }

		// イベントハンドラー

		// メソッド
		internal void SetHandler() {
			this.SetFieldDisabledHandler(() => this.IsEnabled = false);
		}

		protected internal abstract Line CreateLine(LineCollection lineCollection, Apex prev, Apex current);

		protected abstract void SetFieldDisabledHandler(Action disableFiledMethod);

		protected internal abstract void DelselectAll();

		public Rectangle GetRectangle() {
			double beginLeft;
			double beginTop;
			double endLeft;
			double endTop;
			this.GetRectanglePosition(out beginLeft, out beginTop, out endLeft, out endTop);

			return new Rectangle(this, beginLeft, beginTop, endLeft, endTop);
		}

		protected abstract void GetRectanglePosition(out double beginLeft, out double beginTop, out double endLeft, out double endTop);

		// スタティックコンストラクター

		// スタティックフィールド

		// スタティックプロパティ

		// スタティックメソッド
	}
}
