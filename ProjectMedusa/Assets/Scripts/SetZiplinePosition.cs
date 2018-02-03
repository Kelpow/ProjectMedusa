using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class SetZiplinePosition : MonoBehaviour {

	Transform thisTF;

	[SerializeField]
	Transform pointA;
	[SerializeField]
	Transform pointB;

	void Start () {
		thisTF = GetComponent<Transform> ();
	}

	void Update () {
		Vector3 median = (pointA.position + pointB.position) / 2;
		float distance = Vector3.Distance (pointA.position, pointB.position);

		thisTF.position = median;
		thisTF.localScale = new Vector3 (thisTF.localScale.x, distance / 2, thisTF.localScale.z);
		thisTF.LookAt (pointA);
		thisTF.RotateAround (thisTF.position, thisTF.right, 90f);

	}
}
