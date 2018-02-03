using UnityEngine;
using System.Collections;

public class LerpToPointAt : MonoBehaviour {

	Transform thisTF;
	[SerializeField]
	Transform LerpTo;
	[SerializeField]
	float t;
	[SerializeField]
	Transform LookAt;

	void Start () {
		thisTF = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		thisTF.position = Vector3.Lerp (thisTF.position, LerpTo.position, t);
		thisTF.LookAt (LookAt);
	}
}
