using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Tools.Ribbon;

namespace VisGeek.Apps.OfficeLineArt.Ribbon {
	internal static class ExtensionMethods {
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
