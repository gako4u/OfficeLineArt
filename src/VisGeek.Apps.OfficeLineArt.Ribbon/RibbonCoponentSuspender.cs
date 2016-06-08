using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisGeek.Apps.OfficeLineArt.Ribbon {
	/// <summary>リボンの要素の描画を一時的に止めるクラス。
	/// </summary>
	internal class RibbonCoponentSuspender : IDisposable {
		public RibbonCoponentSuspender(RibbonBase ribbon) {
			ribbon.SuspendLayout();
			this.action =
				() => {
					ribbon.ResumeLayout(false);
					ribbon.PerformLayout();
				};
		}

		public RibbonCoponentSuspender(RibbonComponent ribbonComponent) {
			ribbonComponent.SuspendLayout();
			this.action =
				() => {
					ribbonComponent.ResumeLayout(false);
					ribbonComponent.PerformLayout();
				};
		}

		private readonly Action action;

		public void Dispose() {
			this.action();
		}
	}
}
