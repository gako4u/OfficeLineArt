using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisGeek.Apps.OfficeLineArt {
	internal static class ExtensionMethods {
		public static void ForEach<T>(this IEnumerable<T> source, Action<T> action) {
			foreach (var item in source) {
				action(item);
			}
		}

		public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action) {
			int i = 0;
			foreach (var item in source) {
				action(item, i);
				i++;
			}
		}

		public static string ToString<T>(this IEnumerable<T> source, string separator) {
			return string.Join(separator, source);
		}

		public static bool NextBoolean(this Random random) {
			return random.Next(0, 1) == 0 ? false : true;
		}
	}
}
