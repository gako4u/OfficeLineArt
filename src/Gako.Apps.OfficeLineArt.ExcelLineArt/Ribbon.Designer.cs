namespace Gako.Apps.OfficeLineArt.ExcelLineArt {
	partial class Ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase {
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Ribbon()
			: base(Globals.Factory.GetRibbonFactory()) {
			InitializeComponent();
		}

		/// <summary> 
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region コンポーネント デザイナーで生成されたコード

		/// <summary>
		/// デザイナーのサポートに必要なメソッドです。
		/// このメソッドの内容をコード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent() {
			this.tabLineArt = this.Factory.CreateRibbonTab();
			this.grpLineArt = this.Factory.CreateRibbonGroup();
			this.ddApexCount = this.Factory.CreateRibbonDropDown();
			this.ddAfterImageCount = this.Factory.CreateRibbonDropDown();
			this.toggleButton1 = this.Factory.CreateRibbonToggleButton();
			this.tabLineArt.SuspendLayout();
			this.grpLineArt.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabLineArt
			// 
			this.tabLineArt.Groups.Add(this.grpLineArt);
			this.tabLineArt.Label = "ラインアート";
			this.tabLineArt.Name = "tabLineArt";
			// 
			// grpLineArt
			// 
			this.grpLineArt.Items.Add(this.ddApexCount);
			this.grpLineArt.Items.Add(this.ddAfterImageCount);
			this.grpLineArt.Items.Add(this.toggleButton1);
			this.grpLineArt.Label = "ラインアート";
			this.grpLineArt.Name = "grpLineArt";
			// 
			// ddApexCount
			// 
			this.ddApexCount.Label = "頂点の数";
			this.ddApexCount.Name = "ddApexCount";
			this.ddApexCount.SizeString = "nn個";
			// 
			// ddAfterImageCount
			// 
			this.ddAfterImageCount.Label = "残像の数";
			this.ddAfterImageCount.Name = "ddAfterImageCount";
			this.ddAfterImageCount.SizeString = "nn個";
			// 
			// toggleButton1
			// 
			this.toggleButton1.Label = "開始/終了";
			this.toggleButton1.Name = "toggleButton1";
			this.toggleButton1.ShowImage = true;
			this.toggleButton1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.toggleButton_Click);
			// 
			// Ribbon
			// 
			this.Name = "Ribbon";
			this.RibbonType = "Microsoft.Excel.Workbook";
			this.Tabs.Add(this.tabLineArt);
			this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon_Load);
			this.tabLineArt.ResumeLayout(false);
			this.tabLineArt.PerformLayout();
			this.grpLineArt.ResumeLayout(false);
			this.grpLineArt.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private Microsoft.Office.Tools.Ribbon.RibbonTab tabLineArt;
		internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpLineArt;
		internal Microsoft.Office.Tools.Ribbon.RibbonDropDown ddApexCount;
		internal Microsoft.Office.Tools.Ribbon.RibbonDropDown ddAfterImageCount;
		internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton toggleButton1;
	}

	partial class ThisRibbonCollection {
		internal Ribbon Ribbon {
			get { return this.GetRibbon<Ribbon>(); }
		}
	}
}
