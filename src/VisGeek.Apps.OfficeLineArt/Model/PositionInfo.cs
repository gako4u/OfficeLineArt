using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisGeek.Apps.OfficeLineArt.Model {
	/// <summary>多角形の頂点の位置の各次元が持つ情報
	/// </summary>
	public struct PositionInfo {
		// コンストラクター
		internal PositionInfo(double maxValue, Direction direction, double value)
			: this(maxValue, direction, value, PositionInfo.GetStepLength(maxValue)) {
		}

		private PositionInfo(double maxValue, Direction direction, double value, double stepLength) {
			this.MaxValue = maxValue;
			this.Direction = direction;
			this.Value = value;
			this.StepLength = stepLength;
		}

		// フィールド

		// インデクサー

		// プロパティ
		private double MaxValue { get; }

		public Direction Direction { get; }

		public double Value { get; }

		public float FloatValue {
			get {
				return (float)this.Value;
			}
		}

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

		public PositionInfo Step() {
			double newValue = this.Value + (this.StepLength * this.Direction.Sign);
			var newDirection = this.Direction;
			double stepLength = this.StepLength;

			// 反射の計算
			double minValue = 0.0;
			double maxValue = this.MaxValue;
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
				stepLength = PositionInfo.GetStepLength(maxValue);
			}

			return new PositionInfo(this.MaxValue, newDirection, newValue, stepLength);
		}

		// スタティックコンストラクター

		// スタティックフィールド

		// スタティックプロパティ

		// スタティックメソッド
		private static double GetStepLength(double maxValue) {
			double minValue = 0.0;
			double length = maxValue - minValue;

			int stepCount = LineArt.Random.Next(50, 100);
			double result = length / stepCount;

			Debug.WriteLine("StepLength:{0}", result);

			return result;
		}
	}
}
