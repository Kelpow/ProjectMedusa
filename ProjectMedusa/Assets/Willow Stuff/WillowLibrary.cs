using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public static class Willow {


	#region Vector Extensions



	/// <summary>
	/// Flatten the Vector along the Y axis.
	/// </summary>
	public static Vector3 Flatten(this Vector3 vector)
	{
		return new Vector3 (vector.x, 0f, vector.z);
	}
	/// <summary>
	/// Flatten the Vector along the specified Axis.
	/// </summary>
	/// <param name="axis">Axis being flattened. "X", "Y", "Z".</param>
	public static Vector3 Flatten(this Vector3 vector, string axis)
	{
		switch (axis) {
		case "x":
		case "X":
			return new Vector3 (0f, vector.y, vector.z);
			break;
		case "y":
		case "Y":
			return new Vector3 (vector.x, 0f, vector.z);
			break;
		case "z":
		case "Z":
			return new Vector3 (vector.x, vector.y, 0f);
			break;
		default:
			return vector;
			break;
		}
	}


	#endregion

	#region Debug Stuff


	#region Draw Cross
	/// <summary>
	/// Draws a cross at the specified position.
	/// </summary>
	public static void DrawCross (Vector3 point)
	{
		Debug.DrawLine(point - Vector3.right * 0.5f, point + Vector3.right * 0.5f);
		Debug.DrawLine(point - Vector3.up * 0.5f, point + Vector3.up * 0.5f);
		Debug.DrawLine(point - Vector3.forward * 0.5f, point + Vector3.forward * 0.5f);
	}
	/// <summary>
	/// Draws a cross at the specified position.
	/// </summary>
	public static void DrawCross (Vector3 point, float size)
	{
		Debug.DrawLine(point - Vector3.right * size, point + Vector3.right * size);
		Debug.DrawLine(point - Vector3.up * size, point + Vector3.up * size);
		Debug.DrawLine(point - Vector3.forward * size, point + Vector3.forward * size);
	}
	/// <summary>
	/// Draws a cross at the specified position.
	/// </summary>
	public static void DrawCross (Vector3 point, Color color)
	{
		Debug.DrawLine(point - Vector3.right * 0.5f, point + Vector3.right * 0.5f, color);
		Debug.DrawLine(point - Vector3.up * 0.5f, point + Vector3.up * 0.5f, color);
		Debug.DrawLine(point - Vector3.forward * 0.5f, point + Vector3.forward * 0.5f, color);
	}
	/// <summary>
	/// Draws a cross at the specified position.
	/// </summary>
	public static void DrawCross (Vector3 point, float size, Color color)
	{
		Debug.DrawLine(point - Vector3.right * size, point + Vector3.right * size, color);
		Debug.DrawLine(point - Vector3.up * size, point + Vector3.up * size, color);
		Debug.DrawLine(point - Vector3.forward * size, point + Vector3.forward * size, color);
	}
	#endregion

	#region Draw Sphere
	static float SQRT3D2 = 0.86602540378f;

	public static void DrawSphere (Vector3 point) {
		
	}

	#endregion

	#endregion

	#region Willow Stuff



	/// <summary>
	/// Find if a point is inside of a Box Collider
	/// </summary>
	/// <param name="point">Point.</param>
	/// <param name="box">BoxCollider.</param>
	public static bool PointInBoxCollider(Vector3 point, BoxCollider box)
	{
		point = box.GetComponent<Transform> ().InverseTransformPoint (point) - box.center;

		Vector3 halfExtents = box.size * 0.5f;

		if (point.x < halfExtents.x && point.x > -halfExtents.x &&
			point.y < halfExtents.y && point.y > -halfExtents.y &&
			point.z < halfExtents.z && point.z > -halfExtents.z) 
		{
			return true;
		} else {
			return false;
		}
	}
	// original post: http://answers.unity3d.com/questions/53989/test-to-see-if-a-vector3-point-is-within-a-boxcoll.html


	/// <summary>
	/// Gets an array of evenly distributed points on a sphere;
	/// </summary>
	/// <param name="n">Number of point</param>
	public static Vector3[] PointsOnSphere (int n) {
		Vector3[] pts = new Vector3[n];
		float inc = Mathf.PI * (3 - Mathf.Sqrt(5));
		float off = 2.0f/ n;
		float x, y, z, r, phi;

		for (int k = 0; k < n; k++){
			y = k * off - 1 + (off /2);
			r = Mathf.Sqrt(1 - y * y);
			phi = k * inc;
			x = Mathf.Cos(phi) * r;
			z = Mathf.Sin(phi) * r;

			pts [k] = new Vector3 (x, y, z);
		}
		return pts;
	}
	// original post: 	https://forum.unity3d.com/threads/evenly-distributed-points-on-a-surface-of-a-sphere.26138/



	#endregion

	#region Cheats
	public static class Dupe {

		[System.Serializable]
		public class Cheat
		{
			public string cheatCode;
			public UnityEvent codeActivate;
			public UnityEvent codeDeactivate;
			[HideInInspector] public bool isActive;
			public void Toggle()
			{
				isActive = !isActive;

				if (isActive) {
					codeActivate.Invoke ();
				} else {
					codeDeactivate.Invoke ();
				}
			}
		}


		public static string input = "";
		public static bool entered;

		public static bool Cheating ()
		{// 13 is the hash code for the enter key; 8 is the hash code for backspace; 96 = `; 126 = ~;
			if (entered || input.Length > 25)
				input = "";
			if (Input.inputString.GetHashCode () == 8) {
				input = input.Substring (0, input.Length - 1);
				return false;
			}
			if (Input.inputString.GetHashCode () != 13) {
				input += Input.inputString;
				entered = false;
				return false;
			} else {
				entered = true;
				return true;
			}

		}
	}
	#endregion
}
