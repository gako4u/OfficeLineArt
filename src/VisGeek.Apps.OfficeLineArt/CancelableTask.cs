using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VisGeek.Apps.OfficeLineArt {
	public class CancelableTask : IDisposable {
		// コンストラクター
		public CancelableTask(Action<CancellationToken> action) {
			this.task = new Task(() => action(this.canceler.Token));
		}

		// フィールド
		private readonly Task task;

		private readonly CancellationTokenSource canceler = new CancellationTokenSource();

		// プロパティ
		public bool IsDisposed { get; private set; } = false;

		public bool IsCompleted {
			get {
				return this.task.IsCompleted;
			}
		}

		// メソッド
		public TaskAwaiter GetAwaiter() {
			return this.task.GetAwaiter();
		}

		public void Start() {
			this.task.Start();
		}

		public void RunSynchronously() {
			this.task.RunSynchronously();
		}

		public void Cancel() {
			this.canceler.Cancel();
		}

		public void Dispose() {
			Dispose(true);
		}

		protected virtual void Dispose(bool disposing) {
			if (!this.IsDisposed) {
				if (disposing) {
					this.canceler.Dispose();
				}

				this.IsDisposed = true;
			}
		}
	}
}
