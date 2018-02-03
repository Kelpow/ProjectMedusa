using UnityEngine;
using System.Collections;

public class TestPlatform : MonoBehaviour {

	Transform thisTF;

	// Use this for initialization
	void Start () {
		thisTF = GetComponent<Transform> ();
	}

	float right = 1;

	// Update is called once per frame
	void Update () {
		/*
		if (Mathf.Abs (thisTF.position.z) > 3)
			right = -right;
		thisTF.position += Vector3.forward * 0.05f * right;
		*/

		thisTF.RotateAround (thisTF.position, Vector3.up, 3);

	}
}
