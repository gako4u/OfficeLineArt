﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisGeek.Apps.OfficeLineArt.VisioLineArt {
	partial class ThisRibbonCollection {
		internal Ribbon Ribbon {
			get { return this.GetRibbon<Ribbon>(); }
		}
	}
}
