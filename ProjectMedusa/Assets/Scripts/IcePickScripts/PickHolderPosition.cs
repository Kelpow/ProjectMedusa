using UnityEngine;
using System.Collections;

public class PickHolderPosition : MonoBehaviour {

	Transform thisTF;
	public Quaternion zero;

	void Start () {
		thisTF = GetComponent <Transform> ();
		zero = thisTF.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
		thisTF.localRotation = zero;

		thisTF.LookAt (thisTF.position + new Vector3 (thisTF.forward.x, 0f, thisTF.forward.z));
	}
}