using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Tools.Ribbon;
using System.Threading;

namespace VisGeek.Apps.OfficeLineArt.Ribbon {
	/// <summary>リボンの要素を作成して配置するクラスです。
	/// </summary>
	public abstract class RibbonDesigner {
		// コンストラクター
		protected RibbonDesigner(RibbonBase ribbon, bool background) {
			try {
				this.background = background;

				using (new RibbonCoponentSuspender(ribbon)) {
					// タブ
					var tab = ribbon.Factory.CreateRibbonTab("ラインアート");
					using (new RibbonCoponentSuspender(tab)) {
						ribbon.Tabs.Add(tab);

						// グループ
						var group = ribbon.Factory.CreateRibbonGroup("ラインアート");
						using (new RibbonCoponentSuspender(group)) {
							tab.Groups.Add(group);

							// 頂点の数の項目ドロップダウン
							this.apexCountDropDown = this.CreateDropDown(ribbon.Factory, "頂点の数", 3, 6);
							group.Items.Add(this.apexCountDropDown);

							// 残像の数の項目ドロップダウン
							this.afterImageCountDropDown = this.CreateDropDown(ribbon.Factory, "残像の数", 0, 10);
							group.Items.Add(this.afterImageCountDropDown);

							// 開始ボタン
							this.toggleButton = ribbon.Factory.CreateRibbonToggleButton("開始/終了");
							this.toggleButton.ShowImage = true;
							this.toggleButton.Click += this.toggleButton_Click;
							group.Items.Add(this.toggleButton);

						}
					}
				}

			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
				MessageBox.Show(ex.StackTrace);
			}
		}

		// フィールド
		private readonly bool background;

		private readonly RibbonDropDown apexCountDropDown;
		private readonly RibbonDropDown afterImageCountDropDown;
		private readonly RibbonToggleButton toggleButton;

		// プロパティ
		protected bool ApplicationClosed { get; set; } = false;

		protected CancelableTask Task { get; private set; } = null;

		// イベントハンドラー
		private async void toggleButton_Click(object sender, RibbonControlEventArgs e) {
			try {
				if (this.Task == null || this.Task.IsCompleted) {
					var lineArt = this.CreateLineArt();

					try {
						this.apexCountDropDown.Enabled = false;
						this.afterImageCountDropDown.Enabled = false;

						int apexCount = (int)this.apexCountDropDown.SelectedItem.Tag;
						int afterImageCount = (int)this.afterImageCountDropDown.SelectedItem.Tag;

						this.Task = new CancelableTask(canceler => lineArt.Start(apexCount, afterImageCount, canceler));
						if (background) {
							this.Task.Start();
							await this.Task;
						} else {
							this.Task.RunSynchronously();
						}

					} finally {
						this.Task?.Dispose();
						this.Task = null;
						if (!this.ApplicationClosed) {
							this.apexCountDropDown.Enabled = true;
							this.afterImageCountDropDown.Enabled = true;
							this.toggleButton.Enabled = true;
							this.toggleButton.Checked = false;
						}
					}

				} else {
					this.Task.Cancel();
					this.toggleButton.Enabled = false;
				}

			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
				MessageBox.Show(ex.StackTrace);
			}
		}

		// メソッド
		private RibbonDropDown CreateDropDown(RibbonFactory factory, string label, int minItemCount, int maxItemCount) {
			var result = factory.CreateRibbonDropDown(label);
			result.SizeString = "nn個";

			// アイテム追加
			for (int i = minItemCount; i <= maxItemCount; i++) {
				var item = factory.CreateRibbonDropDownItem($"{i}個");
				item.Tag = i;
				result.Items.Add(item);
			}

			return result;
		}

		protected abstract LineArt CreateLineArt();
	}
}
