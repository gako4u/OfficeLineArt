using System;
using System.Threading;
using System.Threading.Tasks;

namespace VisGeek.Apps.OfficeLineArt {
	/// <summary>ラインアートの抽象クラス
	/// </summary>
	public abstract class LineArt {
		// コンストラクター
		protected LineArt() {
			this.IsRunning = false;
		}

		// フィールド
		private readonly object lockObj = new object();

		private bool _isRunning;

		// インデクサー

		// プロパティ
		public bool IsRunning {
			get {
				lock (this.lockObj) {
					return this._isRunning;
				}
			}

			set {
				lock (this.lockObj) {
					this._isRunning = value;
				}
			}
		}

		public bool CancellationRequest { get; private set; }

		// イベントハンドラー

		// メソッド
		public void Cancel() {
			this.CancellationRequest = true;
		}

		public void Start(int apexCount, int afterImageCount) {
			if (this.trySetRunning()) {
				this.CancellationRequest = false;
				var field = this.CreateField(this, apexCount, afterImageCount);
				field.SetHandler();
				var polygons = new PoLygonCollection(field, apexCount, afterImageCount + 1, new Color(255, 255, 0, 0));

				long count = 0;
				DateTime nextFrame = DateTime.Now.Add(LineArt.FrameInterval);
				while (true) {
					count++;

					if (this.CancellationRequest) {
						break;

					} else if (!field.IsEnabled) {
						break;

					} else {
						polygons.Move();

						DateTime now = DateTime.Now;
						if (now < nextFrame) {
							this.Invoke(() => {
								polygons.RefrectPositions();
								this.Draw();
							});

							now = DateTime.Now;
							if (now < nextFrame) {
								this.Sleep(nextFrame - now);
							}
						} else if (count % 100 == 0) {
							//this.Draw();
						}

						nextFrame += LineArt.FrameInterval;
					}
				}

				this.IsRunning = false;
			}
		}

		protected abstract void Draw();

		protected abstract void Sleep(TimeSpan timeSpan);

		protected abstract Field CreateField(LineArt lineArt, int apexCount, int afterImageCount);

		internal void Invoke(Action action) {
			this.Invoke<object>(
				() => {
					action();
					return null;
				}
			);
		}

		protected internal virtual T Invoke<T>(Func<T> action) {
			return action();
		}

		private bool trySetRunning() {
			bool result = false;

			lock (this.lockObj) {
				if (!this.IsRunning) {
					this.IsRunning = true;
					result = true;
				}
			}

			return result;
		}

		// スタティックコンストラクター
		static LineArt() {
			LineArt.FramePerSecond = 30;
			LineArt.FrameInterval = new TimeSpan(TimeSpan.TicksPerSecond / LineArt.FramePerSecond);
		}

		// スタティックフィールド
		private static readonly int FramePerSecond;

		private static readonly TimeSpan FrameInterval;

		// スタティックプロパティ
		internal static Random Random { get; } = new Random();

		// スタティックメソッド
	}
}
