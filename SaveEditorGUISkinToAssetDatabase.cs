using UnityEngine;
using UnityEditor;
using System.Reflection;

namespace EditorFormulas.Formulas
{
	public static class SaveEditorGUISkinToAssetDatabase {

		[FormulaAttribute ("Save Editor GUISkin To Asset Database", "Saves the GUISkin used by the Editor to your Project. Useful for trying to replicate Editor controls in your own tools.", "VoxelBoy")]
		public static void Run()
		{
			var currentGUISkin = typeof(GUISkin).GetField("current", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static).GetValue(null) as GUISkin;

			var newGUISkin = Object.Instantiate(currentGUISkin);
			newGUISkin.hideFlags = HideFlags.None;

			var assetPath = AssetDatabase.GenerateUniqueAssetPath("Assets/EditorGUISkin.guiskin");

			AssetDatabase.CreateAsset (newGUISkin, assetPath);
			AssetDatabase.SaveAssets ();
			AssetDatabase.Refresh();
		}

	}
}
