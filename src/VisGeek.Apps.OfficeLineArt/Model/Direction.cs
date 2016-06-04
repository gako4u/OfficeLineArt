using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisGeek.Apps.OfficeLineArt.Model {
	/// <summary>頂点の進行方向
	/// </summary>
	public struct Direction {
		// コンストラクター
		private Direction(string displayName, int sign) {
			this.DisplayName = displayName;
			this.Sign = sign;
		}

		// プロパティ
		public string DisplayName { get; }

		public int Sign { get; }

		// メソッド
		public override string ToString() {
			return this.DisplayName;
		}

		/// <summary>このオブジェクトのハッシュコードを取得します。
		/// </summary>
		/// <returns>このオブジェクトのハッシュコード。</returns>
		public override int GetHashCode() {
			return this.Sign;
		}

		/// <summary>指定したオブジェクトがこのオブジェクトと等しいかどうかを判断します。
		/// </summary>
		/// <param name="obj">このオブジェクトと比較するオブジェクト。</param>
		/// <returns>指定したオブジェクトがこのオブジェクトと等しい場合は true。等しくない場合は false。</returns>
		public override bool Equals(object obj) {
			bool result = this.Equals(obj is Direction) && this.Equals((Direction)obj);
			return result;
		}

		public bool Equals(Direction obj) {
			bool result = false;

			if (object.ReferenceEquals(obj, this)) {
				result = true;
			} else if (this.Sign == obj.Sign) {
				result = true;
			}

			return result;
		}

		// スタティックコンストラクター

		// スタティックフィールド

		// スタティックプロパティ
		public static Direction Positive = new Direction("Positive", 1);

		public static Direction Negative = new Direction("Negative", -1);

		// スタティックメソッド
		internal static Direction GetRandom() {
			return LineArt.Random.NextBoolean() ? Direction.Positive : Direction.Negative;
		}

		/// <summary>== 演算子
		/// </summary>
		/// <param name="left">左辺値。</param>
		/// <param name="right">右辺値。</param>
		/// <returns>左辺値と右辺値が等しい場合は true。等しくない場合は false。</returns>
		public static bool operator ==(Direction left, Direction right) {
			return object.ReferenceEquals(left, right) || (!object.ReferenceEquals(left, null) && left.Equals(right));
		}

		/// <summary>!= 演算子
		/// </summary>
		/// <param name="left">左辺値。</param>
		/// <param name="right">右辺値。</param>
		/// <returns>左辺値と右辺値が等しくない場合は true。等しい場合は false。</returns>
		public static bool operator !=(Direction left, Direction right) {
			return !(left == right);
		}

		public static Direction operator !(Direction obj) {
			if (obj == Direction.Positive) {
				return Direction.Negative;
			} else {
				return Direction.Positive;
			}
		}
	}
}
