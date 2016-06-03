using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VisGeek.Apps.OfficeLineArt.WpfLineArt {
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window {
		// コンストラクター
		public MainWindow() {
			this.InitializeComponent();
		}

		// フィールド
		private LineArt lineArt;

		// イベントハンドラー
		private void Window_Loaded(object sender, RoutedEventArgs e) {
			//var polygon = new Polygon();
			//polygon.Points.Add(new Point(0, this.canvas.ActualHeight - 0));
			//polygon.Points.Add(new Point(100, this.canvas.ActualHeight - 0));
			//polygon.Points.Add(new Point(100, this.canvas.ActualHeight - 100));
			//polygon.Stroke = Brushes.Black;
			//polygon.Fill = Brushes.SkyBlue;
			//this.canvas.Children.Add(polygon);
			this.lineArt = new LineArt(this, this.canvas);
		}

		private void Window_KeyDown(object sender, KeyEventArgs e) {
			switch (e.Key) {
				case Key.Escape:
					this.Close();
					break;

				default:
					break;
			}

		}

		private void MenuItemExit_Click(object sender, RoutedEventArgs e) {
			this.Close();
		}

		private void StartButton_Click(object sender, RoutedEventArgs e) {
			Task.Factory.StartNew(() => this.lineArt.Start
			(3, 6));
		}
	}
}
