using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Tools.Ribbon;

namespace VisGeek.Apps.OfficeLineArt {
	/// <summary>リボンの要素を作成して配置するクラスです。
	/// </summary>
	public class RibbonDesigner {
		// コンストラクター
		public RibbonDesigner(RibbonBase ribbon, Func<LineArt> lineArtCreator) {
			try {
				this.lineArtCreator = lineArtCreator;
				this.lineArt = null;

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
		private readonly Func<LineArt> lineArtCreator;
		private LineArt lineArt;

		private readonly RibbonDropDown apexCountDropDown;
		private readonly RibbonDropDown afterImageCountDropDown;
		private readonly RibbonToggleButton toggleButton;

		// インデクサー

		// プロパティ

		// イベントハンドラー
		private void toggleButton_Click(object sender, RibbonControlEventArgs e) {
			try {
				if (this.lineArt == null) {
					this.lineArt = this.lineArtCreator();
				}

				if (this.toggleButton.Checked) {
					this.apexCountDropDown.Enabled = false;
					this.afterImageCountDropDown.Enabled = false;

					int apexCount = (int)this.apexCountDropDown.SelectedItem.Tag;
					int afterImageCount = (int)this.afterImageCountDropDown.SelectedItem.Tag;
					this.lineArt.Start(apexCount, afterImageCount);

					this.apexCountDropDown.Enabled = true;
					this.afterImageCountDropDown.Enabled = true;
					this.toggleButton.Enabled = true;
					this.toggleButton.Checked = false;

				} else {
					this.toggleButton.Enabled = false;
					this.lineArt.Cancel();
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

		// スタティックコンストラクター

		// スタティックフィールド

		// スタティックプロパティ

		// スタティックメソッド

		// クラス
		/// <summary>リボンの要素の描画を一時的に止めるクラス。
		/// </summary>
		private class RibbonCoponentSuspender : IDisposable {
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
}
