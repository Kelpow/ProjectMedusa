using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTutorialPointAt : MonoBehaviour {

	Transform thisTF;
	[SerializeField] Transform target;

	void Start () {
		thisTF = GetComponent<Transform> ();
	}

	void Update () {
		thisTF.LookAt (target);
	}
}
