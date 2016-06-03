using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisGeek.Apps.OfficeLineArt {
	public struct Color {
		public Color(byte a, byte r, byte g, byte b) {
			this.A = a;
			this.R = r;
			this.G = g;
			this.B = b;
		}

		public byte A { get; }

		public byte B { get; }

		public byte G { get; }

		public byte R { get; }

		public double Transparency {
			get {
				return (255 - this.A) / 255.0;
			}
		}
	}
}
