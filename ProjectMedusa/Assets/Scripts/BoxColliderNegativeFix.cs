using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderNegativeFix : MonoBehaviour {

	BoxCollider box;
	Transform tf;
	void Start () {
		if (!GetComponent<BoxCollider> ())
			return;

		box = GetComponent<BoxCollider> ();
		tf = GetComponent<Transform> ();
		Vector3 sizeMult;
		float x = tf.lossyScale.x >= 0f ? 1f : -1f;
		float y = tf.lossyScale.y >= 0f ? 1f : -1f;
		float z = tf.lossyScale.z >= 0f ? 1f : -1f;
		sizeMult = new Vector3 (x, y, z);
		box.size = Vector3.Scale (box.size, sizeMult);
	}
}
