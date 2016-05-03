using System;

namespace VisGeek.Apps.OfficeLineArt {
	/// <summary>頂点
	/// </summary>
	public class Apex {
		// コンストラクター
		internal Apex(Polygon polygon) {
			this.Polygon = polygon;
			var field = polygon.Polygons.Field;

			this.X =
				new PositionInfo(
					() => field.GetRectangle().Begin.X
					, () => field.GetRectangle().End.X
					, Direction.GetRandom()
					, 0
				);

			this.Y =
				new PositionInfo(
					() => field.GetRectangle().Begin.Y
					, () => field.GetRectangle().End.Y
					, Direction.GetRandom()
					, 0
				);
		}

		// フィールド

		// インデクサー

		// プロパティ
		public Polygon Polygon { get; }

		public PositionInfo X { get; private set; }

		public PositionInfo Y { get; private set; }

		// イベントハンドラー

		// メソッド
		public override string ToString() {
			return string.Format("{0}:{1} {2}:{3}", nameof(this.X), this.X, nameof(this.Y), this.Y);
		}

		internal void Move() {
			this.X = this.X.Step();
			this.Y = this.Y.Step();
		}

		internal void MoveTo(Apex other) {
			this.X = other.X;
			this.Y = other.Y;
		}

		// スタティックコンストラクター

		// スタティックフィールド

		// スタティックプロパティ

		// スタティックメソッド
	}
}
