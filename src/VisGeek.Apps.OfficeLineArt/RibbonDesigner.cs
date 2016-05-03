using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Tools.Ribbon;

namespace VisGeek.Apps.OfficeLineArt {
	public class RibbonDesigner {
		// コンストラクター
		public RibbonDesigner(RibbonBase ribbon, Func<LineArt> lineArtCreator) {
			try {
				this.ribbon = ribbon;
				this.lineArtCreator = lineArtCreator;
				this.lineArt = null;

				ribbon.SuspendLayout();

				// タブ
				var tab = ribbon.Factory.CreateRibbonTab();
				tab.SuspendLayout();
				tab.Label = "ラインアート";

				// グループ
				var group = ribbon.Factory.CreateRibbonGroup();
				group.SuspendLayout();
				group.Label = "ラインアート";
				tab.Groups.Add(group);

				// 頂点の数の項目ドロップダウン
				this.apexCountDropDown = ribbon.Factory.CreateRibbonDropDown();
				this.apexCountDropDown.Label = "頂点の数";
				this.apexCountDropDown.SizeString = "nn個";
				foreach (int apexCount in Enumerable.Range(3, 4)) {
					var item = ribbon.Factory.CreateRibbonDropDownItem();
					item.Label = string.Format("{0}個", apexCount);
					item.Tag = apexCount;
					this.apexCountDropDown.Items.Add(item);
				}
				group.Items.Add(this.apexCountDropDown);

				// 残像の数の項目ドロップダウン
				this.afterImageCountDropDown = ribbon.Factory.CreateRibbonDropDown();
				this.afterImageCountDropDown.Label = "残像の数";
				this.afterImageCountDropDown.SizeString = "nn個";
				foreach (int afterImageCount in Enumerable.Range(0, 10)) {
					var item = ribbon.Factory.CreateRibbonDropDownItem();
					item.Label = string.Format("{0}個", afterImageCount);
					item.Tag = afterImageCount;
					this.afterImageCountDropDown.Items.Add(item);
				}
				group.Items.Add(this.afterImageCountDropDown);

				// 開始ボタン
				this.toggleButton = ribbon.Factory.CreateRibbonToggleButton();
				this.toggleButton.Label = "開始/終了";
				this.toggleButton.ShowImage = true;
				this.toggleButton.Click += this.toggleButton_Click;
				group.Items.Add(this.toggleButton);

				ribbon.Tabs.Add(tab);

				tab.ResumeLayout(false);
				tab.PerformLayout();

				group.ResumeLayout(false);
				group.PerformLayout();

				ribbon.ResumeLayout(false);

			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
				MessageBox.Show(ex.StackTrace);
			}
		}

		// フィールド
		private readonly Func<LineArt> lineArtCreator;
		private LineArt lineArt;

		private readonly RibbonBase ribbon;
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

		// スタティックコンストラクター

		// スタティックフィールド

		// スタティックプロパティ

		// スタティックメソッド
	}
}
