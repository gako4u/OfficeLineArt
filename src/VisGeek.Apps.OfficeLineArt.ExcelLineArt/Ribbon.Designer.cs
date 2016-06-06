using VisGeek.Apps.OfficeLineArt.Ribbon;

namespace VisGeek.Apps.OfficeLineArt.ExcelLineArt {
	partial class Ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase {
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Ribbon()
			: base(Globals.Factory.GetRibbonFactory()) {
			this.InitializeComponent();
			new RibbonDesigner(this, () => new LineArt(this.Application));
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
			this.SuspendLayout();
			// 
			// Ribbon
			// 
			this.Name = "Ribbon";
			this.RibbonType = "Microsoft.Excel.Workbook";
			this.ResumeLayout(false);

		}

		#endregion
	}

	partial class ThisRibbonCollection {
		internal Ribbon Ribbon {
			get { return this.GetRibbon<Ribbon>(); }
		}
	}
}
