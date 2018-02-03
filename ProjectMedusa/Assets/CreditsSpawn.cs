using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CreditsSpawn : MonoBehaviour {

	[SerializeField] UnityEvent thing;

	void OnTriggerStay (Collider col)
	{
		if (col.tag == "Hand") {
			thing.Invoke ();
			Destroy (this);
		}
	}
}
