using UnityEngine;
using UnityEditor;
using System.Reflection;

namespace EditorFormulas
{
	public static partial class Formulas {

		public static void ApplyImportSettingsToSelectedAssets(Object originalAsset)
		{
			if(!AssetDatabase.Contains(originalAsset))
			{
				Debug.LogError("The object given as the original asset is not in the asset database. Make sure you've specified an actual asset and not a scene object.");
				return;
			}

			var originalAssetPath = AssetDatabase.GetAssetPath(originalAsset);
			var originalAssetImporter = AssetImporter.GetAtPath(originalAssetPath);
			if(originalAssetImporter == null)
			{
				Debug.LogError("There is no valid importer for the given asset.");
			}

			var selectedObjects = Selection.objects;
			foreach(var obj in selectedObjects)
			{
				if(obj == null)
				{
					continue;
				}
				if(!AssetDatabase.Contains(obj))
				{
					Debug.LogError("The selected object " + obj.name + " is not in the asset database", obj);
					continue;
				}
				var objAssetPath = AssetDatabase.GetAssetPath(obj);
				var objAssetImporter = AssetImporter.GetAtPath(objAssetPath);
				if(objAssetImporter == null)
				{
					Debug.LogError("The selected object " + obj.name + " has no valid importer.", obj);
					continue;
				}
				if(objAssetImporter.GetType() != originalAssetImporter.GetType())
				{
					Debug.LogError("The selected object's asset importer is not of the same type as the original object's asset importer.");
					continue;
				}

				//Get all public properties of original asset importer and apply them to objAssetImporter
				var properties = originalAssetImporter.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

				foreach(var property in properties)
				{
					if(property.GetGetMethod() != null && property.GetSetMethod() != null)
					{
						var val = property.GetValue(originalAssetImporter, null);
						property.SetValue(objAssetImporter, val, null);
					}
				}
				objAssetImporter.SaveAndReimport();
			}

			AssetDatabase.Refresh();
		}
	}
}
