using System;

namespace VisGeek.Apps.OfficeLineArt {
	/// <summary>頂点
	/// </summary>
	public class Apex {
		// コンストラクター
		internal Apex(Polygon polygon) {
			this.Polygon = polygon;
			var field = polygon.Polygons.Field;

			this.Left =
				new PositionInfo(
					() => field.GetRectangle().LeftTop.Left
					, () => field.GetRectangle().RightBottom.Left
					, Direction.GetRandom()
					, 0
				);

			this.Top =
				new PositionInfo(
					() => field.GetRectangle().LeftTop.Top
					, () => field.GetRectangle().RightBottom.Top
					, Direction.GetRandom()
					, 0
				);
		}

		// フィールド

		// インデクサー

		// プロパティ
		public Polygon Polygon { get; }

		public PositionInfo Left { get; private set; }

		public PositionInfo Top { get; private set; }

		// イベントハンドラー

		// メソッド
		public override string ToString() {
			return string.Format("Left:{0} Top:{1}", this.Left, this.Top);
		}

		internal void Move() {
			this.Left = this.Left.Step();
			this.Top = this.Top.Step();
		}

		internal void MoveTo(Apex other) {
			this.Left = other.Left;
			this.Top = other.Top;
		}

		// スタティックコンストラクター

		// スタティックフィールド

		// スタティックプロパティ

		// スタティックメソッド
	}
}
