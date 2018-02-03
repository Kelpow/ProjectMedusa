using UnityEngine;
using System.Collections;

public class WalkAndTalkEndArea : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") {
			GameObject.Find ("Director").SendMessage("BeginAct", "Reset tutorial");
			Destroy (this.gameObject);
		}
	}
}
