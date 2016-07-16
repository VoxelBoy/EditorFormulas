using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace EditorFormulas
{
	public static partial class Formulas {

		public static void ReportBoundsOfSelectedObjects(bool reportRendererBounds, bool reportColliderBounds, bool encapsulateChildren)
		{
			var selection = Selection.objects;
			foreach(GameObject go in selection)
			{
				if(reportRendererBounds)
				{
					var bounds = new Bounds(go.transform.position, Vector3.zero);
					var rendererOnObject = go.GetComponent<Renderer>();
					if(rendererOnObject != null)
					{
						bounds = rendererOnObject.bounds;
					}
					if(encapsulateChildren)
					{
						var renderersInChildren = go.GetComponentsInChildren<Renderer>();
						foreach(var rend in renderersInChildren)
						{
							bounds.Encapsulate(rend.bounds);
						}
					}

					Debug.Log(string.Format("Renderer bounds of {0} is center:{1} size:{2}",
											go.name,
											FullVector3String_ReportBoundsOfSelectedObjects(bounds.center),
											FullVector3String_ReportBoundsOfSelectedObjects(bounds.size)));
				}
				if(reportColliderBounds)
				{
					var bounds = new Bounds(go.transform.position, Vector3.zero);
					var colliderOnObject = go.GetComponent<Collider>();
					if(colliderOnObject != null)
					{
						bounds = colliderOnObject.bounds;
					}
					if(encapsulateChildren)
					{
						var collidersInChildren = go.GetComponentsInChildren<Collider>();
						foreach(var col in collidersInChildren)
						{
							bounds.Encapsulate(col.bounds);
						}
					}

					Debug.Log(string.Format("Collider bounds of {0} is center:{1} size:{2}",
						go.name,
						FullVector3String_ReportBoundsOfSelectedObjects(bounds.center),
						FullVector3String_ReportBoundsOfSelectedObjects(bounds.size)));
				}
			}
		}

		private static string FullVector3String_ReportBoundsOfSelectedObjects(Vector3 vector)
		{
			return string.Format("({0},{1},{2})", vector.x, vector.y, vector.z);
		}
	}
}