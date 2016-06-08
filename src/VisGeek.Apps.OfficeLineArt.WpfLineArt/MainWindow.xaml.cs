using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
		private CancelableTask task;

		// イベントハンドラー
		private void Window_Loaded(object sender, RoutedEventArgs e) {
			//var polygon = new Polygon();
			//polygon.Points.Add(new Point(0, this.canvas.ActualHeight - 0));
			//polygon.Points.Add(new Point(100, this.canvas.ActualHeight - 0));
			//polygon.Points.Add(new Point(100, this.canvas.ActualHeight - 100));
			//polygon.Stroke = Brushes.Black;
			//polygon.Fill = Brushes.SkyBlue;
			//this.canvas.Children.Add(polygon);
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

		private async void StartButton_Click(object sender, RoutedEventArgs e) {
			int apexCount = this.GetApexCount();
			int afterImageCount = this.GetAfterImageCount();

			var lineArt = new LineArt(this, this.canvas);

			using (this.task = new CancelableTask(canceler => lineArt.Start(apexCount, afterImageCount, canceler))) {
				this.startButton.IsEnabled = false;
				this.stopButton.IsEnabled = true;
				this.apexCountComboBox.IsEnabled = false;
				this.afterImageCountComboBox.IsEnabled = false;

				this.task.Start();
				await this.task;

				this.canvas.Children.OfType<System.Windows.Shapes.Line>().ToList().ForEach(this.canvas.Children.Remove);
				this.startButton.IsEnabled = true;
				this.stopButton.IsEnabled = false;
				this.apexCountComboBox.IsEnabled = true;
				this.afterImageCountComboBox.IsEnabled = true;
			}
		}

		private int GetApexCount() {
			var selected = (ComboBoxItem) this.apexCountComboBox.SelectedItem;
			var str = (string)selected.DataContext;
			var result = int.Parse(str);
			return result;
		}

		private int GetAfterImageCount() {
			var selected = (ComboBoxItem)this.afterImageCountComboBox.SelectedItem;
			var str = (string)selected.DataContext;
			var result = int.Parse(str);
			return result;
		}

		private void StopButton_Click(object sender, RoutedEventArgs e) {
			this.task?.Cancel();
		}
	}
}
