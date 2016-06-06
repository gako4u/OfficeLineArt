using System;
using System.Threading;
using System.Threading.Tasks;
using VisGeek.Apps.OfficeLineArt.Model;

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

		// プロパティ
		public bool IsRunning {
			get { lock (this.lockObj) { return this._isRunning; } }
			set { lock (this.lockObj) { this._isRunning = value; } }
		}

		public bool CancellationRequest { get; private set; }

		// メソッド
		public void Cancel() {
			this.CancellationRequest = true;
		}

		public void Start(int apexCount, int afterImageCount) {
			if (this.trySetRunning()) {
				this.CancellationRequest = false;
				var fieldModel = new Model.Field(this, 640.0, 480.0, apexCount, afterImageCount);

				using (var fieldView = this.CreateField(fieldModel, new Color(255, 0, 0))) {
					long count = 0;
					DateTime nextFrame = DateTime.Now.Add(LineArt.FrameInterval);
					while (true) {
						count++;

						if (this.CancellationRequest) {
							break;

						} else if (!fieldView.IsEnabled) {
							break;

						} else {
							fieldModel.Polygons.Move();

							DateTime now = DateTime.Now;
							if (now < nextFrame) {
								this.Invoke(() => {
									fieldView.Draw();
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
		}

		protected abstract View.Field CreateField(Field fieldModel, Color color);

		protected abstract void Sleep(TimeSpan timeSpan);

		private void Invoke(Action action) {
			this.Invoke<object>(
				() => {
					action();
					return null;
				}
			);
		}

		protected abstract T Invoke<T>(Func<T> action);

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
