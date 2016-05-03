using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Office = Microsoft.Office.Interop.Excel;

namespace VisGeek.Apps.OfficeLineArt.ExcelLineArt {
	public partial class Ribbon {
		// フィールド
		private LineArt lineArt;

		// プロパティ
		public Office.Application Application {
			get {
				return Globals.ThisAddIn.Application;
			}
		}

		// イベントハンドラー
		private void Ribbon_Load(object sender, RibbonUIEventArgs e) {
			try {
				// 頂点の数の項目
				foreach (int apexCount in Enumerable.Range(3, 4)) {
					var item = this.Factory.CreateRibbonDropDownItem();
					item.Label = string.Format("{0}個", apexCount);
					item.Tag = apexCount;
					this.ddApexCount.Items.Add(item);
				}

				// 残像の数の項目う
				foreach (int afterImageCount in Enumerable.Range(0, 10)) {
					var item = this.Factory.CreateRibbonDropDownItem();
					item.Label = string.Format("{0}個", afterImageCount);
					item.Tag = afterImageCount;
					this.ddAfterImageCount.Items.Add(item);
				}

				this.lineArt = new LineArt(this.Application);
			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
				MessageBox.Show(ex.StackTrace);
			}
		}

		private void toggleButton_Click(object sender, RibbonControlEventArgs e) {
			try {
				if (this.toggleButton1.Checked) {
					this.ddApexCount.Enabled = false;
					this.ddAfterImageCount.Enabled = false;

					int apexCount = (int)this.ddApexCount.SelectedItem.Tag;
					int afterImageCount = (int)this.ddAfterImageCount.SelectedItem.Tag;
					this.lineArt.Start(apexCount, afterImageCount);

					this.ddApexCount.Enabled = true;
					this.ddAfterImageCount.Enabled = true;
					this.toggleButton1.Enabled = true;
					this.toggleButton1.Checked = false;

				} else {
					this.toggleButton1.Enabled = false;
					this.lineArt.Cancel();
				}

			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
				MessageBox.Show(ex.StackTrace);
			}
		}
	}
}
