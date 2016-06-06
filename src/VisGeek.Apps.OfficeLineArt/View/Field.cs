using System;
using System.Diagnostics;
using System.Linq;
using VisGeek.Apps.OfficeLineArt.Model;

namespace VisGeek.Apps.OfficeLineArt.View {
	/// <summary>ラインアートを描画するフィールド
	/// </summary>
	public abstract class Field : IDisposable {
		// コンストラクター
		protected Field(LineArt lineArt, Model.Field fieldModel, Color color) {
			this.LineArt = lineArt;
			this.FieldModel = fieldModel;
			this.LineGroups = new LineGroupCollection(this, color, fieldModel.Polygons);
			this.IsEnabled = true;
		}

		// フィールド
		private bool isDisposed = false;

		// プロパティ
		public LineArt LineArt { get; }

		public LineGroupCollection LineGroups { get; }

		public Model.Field FieldModel { get; }

		public bool IsEnabled { get; private set; }

		// メソッド
		protected void Disable() {
			this.IsEnabled = false;
		}

		protected internal abstract Line CreateLine(LineGroup polygon, Apex begin, Apex end);

		public Rectangle GetRectangle() {
			double beginX;
			double beginY;
			double endX;
			double endY;
			this.GetRectanglePosition(out beginX, out beginY, out endX, out endY);

			return new Rectangle(beginX, beginY, endX, endY);
		}

		protected abstract void GetRectanglePosition(out double beginX, out double beginY, out double endX, out double endY);

		internal void Draw() {
			if (this.IsEnabled) {
				var screen = this.GetRectangle();
				this.LineGroups.ForEach(lineGroup => lineGroup.Draw(screen));
			}
		}

		public void Dispose() {
			if (!this.isDisposed) {
				this.DisposeInternal();
				this.isDisposed = true;
			}
		}

		protected abstract void DisposeInternal();
	}
}
