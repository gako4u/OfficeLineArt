using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace VisGeek.Apps.OfficeLineArt.Ribbon {
	public abstract class LineArt : VisGeek.Apps.OfficeLineArt.LineArt {
		// コンストラクター
		public LineArt(Dispatcher dispatcher) : base() {
			this.dispatcher = dispatcher;
		}

		// フィールド
		private readonly Dispatcher dispatcher;

		// メソッド
		protected sealed override T Invoke<T>(Func<T> action) {
			var invokeResult = this.dispatcher.BeginInvoke(action);
			invokeResult.Wait();
			return (T)invokeResult.Result;
		}
	}
}
