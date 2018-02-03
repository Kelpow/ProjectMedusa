using UnityEngine;
using System.Collections;

public class PickPointBehavior : MonoBehaviour {

	PickBehavior pick;

	void Start()
	{
		pick = GetComponent<Transform> ().parent.GetComponent<PickBehavior> ();
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Ice") {
			pick.IceStab ();
		}
	}
}
