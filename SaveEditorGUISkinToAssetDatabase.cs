using UnityEngine;
using UnityEditor;
using System.Reflection;

namespace EditorFormulas
{
	public static partial class Formulas {

		public static void SaveEditorGUISkinToAssetDatabase()
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
