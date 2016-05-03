using Gako.Collections.Utilities;
using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Gako.Apps.OfficeLineArt.ExcelLineArt {
	public partial class Ribbon {
		// フィールド
		private ExcelLineArt lineArt;

		// プロパティ
		public Excel.Application Excel {
			get {
				return Globals.ThisAddIn.Application;
			}
		}

		// イベントハンドラー
		private void Ribbon_Load(object sender, RibbonUIEventArgs e) {
			try {
				// 頂点の数の項目
				EnumerableUtility.For(3, 6).ForEach(apexCount => {
					var item = this.Factory.CreateRibbonDropDownItem();
					item.Label = string.Format("{0}個", apexCount);
					item.Tag = apexCount;
					this.ddApexCount.Items.Add(item);
				});

				// 残像の数の項目う
				EnumerableUtility.For(0, 10).ForEach(afterImageCount => {
					var item = this.Factory.CreateRibbonDropDownItem();
					item.Label = string.Format("{0}個", afterImageCount);
					item.Tag = afterImageCount;
					this.ddAfterImageCount.Items.Add(item);
				});

				this.lineArt = new ExcelLineArt(this.Excel);
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
