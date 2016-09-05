using UnityEngine;
using UnityEditor;
using System.Reflection;

namespace EditorFormulas.Formulas
{
	public static class SelectEditorGUISkin {

		[FormulaAttribute("Select Editor GUI Skin", "Selects the GUISkin object used by the Editor", "VoxelBoy")]
		public static void Run()
		{
			Selection.activeObject = typeof(GUISkin).GetField("current", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static).GetValue(null) as GUISkin;
		}

	}
}
