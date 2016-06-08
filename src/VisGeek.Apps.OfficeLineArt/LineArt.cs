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
		}

		// メソッド
		public void Start(int apexCount, int afterImageCount, CancellationToken canceler) {
			var fieldModel = new Model.Field(this, 640.0, 480.0, apexCount, afterImageCount);

			var fieldView = this.CreateField(fieldModel, new Color(255, 0, 0));
			DateTime nextFrame = DateTime.Now.Add(LineArt.FrameInterval);

			while (!canceler.IsCancellationRequested) {
				DateTime now = DateTime.Now;
				if (now < nextFrame) {
					// 描画
					this.Invoke(() => {
						if (!canceler.IsCancellationRequested) {
							fieldView.Draw();
							this.DoEvents();
						}
					});

					now = DateTime.Now;
					if (now < nextFrame) {
						Thread.Sleep(nextFrame - now);
					}
				}

				nextFrame += LineArt.FrameInterval;

				// 処理
				fieldModel.Polygons.Move();
			}
		}

		protected abstract View.Field CreateField(Field fieldModel, Color color);

		private void Invoke(Action action) {
			this.Invoke<object>(
				() => {
					action();
					return null;
				}
			);
		}

		protected abstract T Invoke<T>(Func<T> action);

		protected virtual void DoEvents() {
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
