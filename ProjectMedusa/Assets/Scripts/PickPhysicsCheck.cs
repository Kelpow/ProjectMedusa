using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickPhysicsCheck : MonoBehaviour {

	void FixedUpdate()
	{
		//GetComponentInParent<PickBehavior> ().collided = false;
	}

	void OnTriggerStay()
	{
		//GetComponentInParent<PickBehavior> ().collided = true;
	}
}
