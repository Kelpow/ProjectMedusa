using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLookAt : MonoBehaviour {

	Transform thisTF;
	void Start () {
		thisTF = GetComponent<Transform> ();
	}
	
	[SerializeField] Transform target;

	void Update () {
		thisTF.LookAt (target);
	}
}
