using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gako.Apps.OfficeLineArt {
	public struct PositionElement {
		// コンストラクター
		internal PositionElement(Func<double> minValue, Func<double> maxValue, Direction direction, double value)
			: this(minValue, maxValue, direction, value, PositionElement.GetStepLength(minValue(), maxValue())) {
		}

		private PositionElement(Func<double> minValue, Func<double> maxValue, Direction direction, double value, double stepLength) {
			this.MinValue = minValue;
			this.MaxValue = maxValue;
			this.Direction = direction;
			this.Value = value;
			this.StepLength = stepLength;
		}

		// フィールド

		// インデクサー

		// プロパティ
		private Func<double> MinValue { get; }

		private Func<double> MaxValue { get; }

		public Direction Direction { get; }

		public double Value { get; }

		public double StepLength { get; }

		// イベントハンドラー

		// メソッド
		public override string ToString() {
			try {
				return string.Format("Direction:{0,2} Value:{1: #####.000;-#####.000}", this.Direction.Sign, this.Value);
			} catch (Exception) {
				return "";
			}
		}

		public PositionElement Step() {
			double newValue = this.Value + (this.StepLength * this.Direction.Sign);
			var newDirection = this.Direction;
			double stepLength = this.StepLength;

			// 反射の計算
			double minValue = this.MinValue();
			double maxValue = this.MaxValue();
			if (newValue < minValue || maxValue < newValue) {
				double limit;
				if (newDirection == Direction.Positive) {
					limit = maxValue;
					newValue = maxValue;
				} else {
					limit = minValue;
					newValue = minValue;
				}
				newDirection = !newDirection;
				stepLength = PositionElement.GetStepLength(minValue, maxValue);
			}

			return new PositionElement(this.MinValue, this.MaxValue, newDirection, newValue, stepLength);
		}

		// スタティックコンストラクター

		// スタティックフィールド

		// スタティックプロパティ

		// スタティックメソッド
		private static double GetStepLength(double minValue, double maxValue) {
			double length = maxValue - minValue;

			int stepCount = LineArt.Random.Next(50, 100);
			double result = length / stepCount;

			Debug.WriteLine("StepLength:{0}", result);

			return result;			
		}
	}
}
