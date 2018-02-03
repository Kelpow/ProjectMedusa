using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingHandleBehavior : MonoBehaviour {

	Transform thisTF;
	Quaternion rot;

	void Start () {
		thisTF = GetComponent<Transform> ();

		rot = Quaternion.Euler (Vector3.zero);
	}

	void Update () {
		thisTF.rotation = rot;
	}
}
