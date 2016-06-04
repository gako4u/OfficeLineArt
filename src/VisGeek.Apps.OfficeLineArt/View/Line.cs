using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Collections;
using VisGeek.Apps.OfficeLineArt.Model;

namespace VisGeek.Apps.OfficeLineArt.View {
	/// <summary>多角形を構成する線
	/// </summary>
	public abstract class Line {
		// コンストラクター
		protected Line(LineGroup parent, Apex begin, Apex end) {
			this.Parent = parent;
			this.Begin = begin;
			this.End = end;
		}

		// プロパティ
		public LineGroup Parent { get; }

		public Field Field {
			get {
				return this.Parent.Parent.Parent;
			}
		}

		public Apex Begin { get; }

		public Apex End { get; }

		public Color Color {
			get {
				return this.Parent.Parent.Color;
			}
		}

		public double Transparency {
			get {
				return this.Parent.Transparency;
			}
		}

		// メソッド
		public override string ToString() {
			return string.Format("Begin:{2} End:{1}", this.Begin, this.End);
		}

		internal void Draw(Rectangle screen) {
			double beginX = screen.Begin.X + screen.Width * this.Begin.RatioX;
			double beginY = screen.Begin.Y + screen.Height * this.Begin.RatioY;
			double endX = screen.Begin.X + screen.Width * this.End.RatioX;
			double endY = screen.Begin.Y + screen.Height * this.End.RatioY;

			this.Draw(
				  beginX
				, beginY
				, endX
				, endY
			);
		}

		protected internal abstract void Draw(double beginX, double beginY, double endX, double endY);
	}
}
