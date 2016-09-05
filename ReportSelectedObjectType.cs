using UnityEngine;
using UnityEditor;

namespace EditorFormulas.Formulas
{
	public static class ReportSelectedObjectType {

		[FormulaAttribute("Report Selected Object Type", "Reports the System.Type of the selected object in the Editor", "VoxelBoy")]
		public static void Run()
		{
			if(Selection.activeObject == null)
			{
				return;
			}
			Debug.Log(Selection.activeObject.GetType().FullName);
		}
	}
}
