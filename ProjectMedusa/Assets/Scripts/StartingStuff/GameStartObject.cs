using UnityEngine;
using System.Collections;

public class GameStartObject : MonoBehaviour {

	[SerializeField]
	Transform pointer;
	[SerializeField]
	Transform head;
	[SerializeField]
	Transform flag;

	void Update () {
		pointer.position = GetComponent<Transform>().position + new Vector3 (head.forward.x, 0f, head.forward.z);
		GetComponent<Transform> ().LookAt (pointer);
		flag.parent = null;
		Destroy (this);
	}
}
