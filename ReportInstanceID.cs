using UnityEngine;
using UnityEditor;

namespace EditorFormulas.Formulas
{
	public static class ReportInstanceID {

		[FormulaAttribute ("Report Instance ID", "Reports the instanceID of the selected object", "VoxelBoy")]
		public static void Run()
		{
			if(Selection.activeObject != null)
			{
				Debug.Log(Selection.activeObject.GetInstanceID());
			}
		}

	}
}
