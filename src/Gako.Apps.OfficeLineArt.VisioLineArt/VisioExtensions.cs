using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Visio;
using System.Diagnostics;

namespace Gako.Apps.OfficeLineArt.VisioLineArt {
	[DebuggerStepThrough]
	public static class VisioExtensions {
		public static IEnumerable<Page> getPages(this IVDocument document) {
			return document.Pages.Cast<Page>();
		}

		public static Cell GetCellSRC(this Shape shape, VisSectionIndices section, VisRowIndices row, VisCellIndices column) {
			return shape.CellsSRC[(short)section, (short)row, (short)column];
		}

		public static void AddNamedRow(this Shape shape, VisSectionIndices section, string rowName, int rowTag) {
			shape.AddNamedRow((short)section, rowName, 0);
		}

		public static void DeleteRow(this Shape shape, VisSectionIndices section, short row) {
			shape.DeleteRow((short)section, row);
		}

		public static void OpenEx(this Documents documents, string filePath, VisOpenSaveArgs flags) {
			documents.OpenEx(filePath, (short)flags);
		}

		public static bool CellExists(this Shape shape, string localeSpecificCellName, short fExistsLocally) {
			return shape.CellExists[localeSpecificCellName, fExistsLocally] != 0;
		}
	}
}
