using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Tools.Ribbon;

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

		public static RibbonTab CreateRibbonTab(this RibbonFactory factory, string label) {
			var result = factory.CreateRibbonTab();
			result.Label = label;
			return result;
		}

		public static RibbonGroup CreateRibbonGroup(this RibbonFactory factory, string label) {
			var result = factory.CreateRibbonGroup();
			result.Label = label;
			return result;
		}

		public static RibbonDropDown CreateRibbonDropDown(this RibbonFactory factory, string label) {
			var result = factory.CreateRibbonDropDown();
			result.Label = label;
			return result;
		}

		public static RibbonDropDownItem CreateRibbonDropDownItem(this RibbonFactory factory, string label) {
			var result = factory.CreateRibbonDropDownItem();
			result.Label = label;
			return result;
		}

		public static RibbonToggleButton CreateRibbonToggleButton(this RibbonFactory factory, string label) {
			var result = factory.CreateRibbonToggleButton();
			result.Label = label;
			return result;
		}
	}
}
