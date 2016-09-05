using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace EditorFormulas.Formulas
{
	public static class GroundSelectedObjects {

		//Assumes gravity in -Y direction
		//Does 4 raycasts, one from each corner of the bottom of the bounds
		[FormulaAttribute ("Ground Selected Objects", "Tries to place the selected objects on whatever surface is beneath them", "VoxelBoy")]
		public static void Run(float distanceFromGround, LayerMask raycastLayerMask)
		{
			var selectedSceneObjects = Selection.GetFiltered(typeof(Transform), SelectionMode.Editable | SelectionMode.ExcludePrefab);
			if(selectedSceneObjects.Length == 0)
			{
				Debug.Log("No transforms among selected objects.");
				return;
			}
			foreach(Transform t in selectedSceneObjects)
			{
				var colliders = new List<Collider>();
				//Add the colliders on the root game object
				var collidersOnRoot = t.GetComponents<Collider>();
				colliders.AddRange(collidersOnRoot);
				//Add the colliders in the children
				t.GetComponentsInChildren<Collider>(colliders);
				if(colliders.Count == 0)
				{
					Debug.Log("Skipping because no colliders found on " + t.name);
					continue;
				}
				//Start with the first collider's bounds
				Bounds bounds = colliders[0].bounds;
				for(int i=1; i<colliders.Count; i++)
				{
					bounds.Encapsulate(colliders[i].bounds);
				}

				//TODO: For primitive colliders maybe use Physics methods such as BoxCast, SphereCast, CapsuleCast

				Vector3[] corners = new Vector3[4];
				corners[0] = new Vector3(bounds.min.x, bounds.min.y, bounds.min.z);
				corners[1] = new Vector3(bounds.min.x, bounds.min.y, bounds.max.z);
				corners[2] = new Vector3(bounds.max.x, bounds.min.y, bounds.min.z);
				corners[3] = new Vector3(bounds.max.x, bounds.min.y, bounds.max.z);

				float smallestDistanceToGround = float.MaxValue;
				for(int i=0; i<corners.Length; i++)
				{
					RaycastHit hit;
					var ray = new Ray(corners[i], Vector3.down);
					if(Physics.Raycast(ray, out hit, float.MaxValue, raycastLayerMask.value))
					{
						var distance = Vector3.Distance(corners[i], hit.point);
						if(distance < smallestDistanceToGround)
						{
							smallestDistanceToGround = distance;
						}
					}
				}

				//If smallest distance to ground is still float.MaxValue
				//That means none of the 4 raycasts hit anything
				if(smallestDistanceToGround == float.MaxValue)
				{
					Debug.Log("No colliders found below " + t.name + " to ground it to. Its transform won't be modified.");
					continue;
				}

				Undo.RecordObject(t, "Ground " + t.name);
				t.position += Vector3.down * (smallestDistanceToGround - distanceFromGround);
			}
		}
	}
}
