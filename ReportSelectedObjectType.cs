using UnityEngine;
using UnityEditor;

namespace EditorFormulas
{
	public static partial class Formulas {

		public static void ReportSelectedObjectType()
		{
			if(Selection.activeObject == null)
			{
				return;
			}
			Debug.Log(Selection.activeObject.GetType().FullName);
		}
	}
}
