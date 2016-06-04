using System;
using System.Diagnostics;
using System.Linq;


namespace VisGeek.Apps.OfficeLineArt {
	/// <summary>ラインアートを描画するフィールド
	/// </summary>
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

		protected internal abstract Line CreateLine(Polygon polygon, Apex prev, Apex current);

		protected abstract void SetFieldDisabledHandler(Action disableFiledMethod);

		protected internal abstract void DelselectAll();

		public Rectangle GetRectangle() {
			double beginX;
			double beginY;
			double endX;
			double endY;
			this.GetRectanglePosition(out beginX, out beginY, out endX, out endY);

			return new Rectangle(beginX, beginY, endX, endY);
		}

		protected abstract void GetRectanglePosition(out double beginX, out double beginY, out double endX, out double endY);
	}
}
