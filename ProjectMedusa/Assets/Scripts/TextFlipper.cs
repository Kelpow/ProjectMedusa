using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFlipper : MonoBehaviour {

	[ContextMenu("Do A Kick Flip")]
	void DoAKickFlip()
	{
		FlipAllChildrenRecursively (GetComponent<Transform> ());
	}

	void FlipAllChildrenRecursively (Transform tf)
	{
		if (tf.GetComponent<TextMesh> ()) {
			Flip (tf);
			tf.GetComponent<TextMesh> ().anchor = TextAnchor.MiddleRight;
		}
		foreach (Transform child in tf) {
			FlipAllChildrenRecursively (child);
		}
	}

	void Flip(Transform tf)
	{
		tf.localScale = new Vector3 (-tf.localScale.x, tf.localScale.y, tf.localScale.z); 
	}

}
