using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisGeek.Apps.OfficeLineArt {
	public struct Color {
		public Color(byte r, byte g, byte b) {
			this.R = r;
			this.G = g;
			this.B = b;
		}

		public byte B { get; }

		public byte G { get; }

		public byte R { get; }

		//public double Transparency {
		//	get {
		//		return (255 - this.A) / 255.0;
		//	}
		//}
	}
}
