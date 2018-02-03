using UnityEngine;
using System.Collections;

public class FlagDeleteStart : MonoBehaviour {
	[SerializeField]
	GameObject gameStart;
	void OnTriggerStay (Collider col)
	{
		if (col.tag == "Hand") {
			if (col.gameObject.GetComponent<ClickAndDrag> ().grabbing) {
				Destroy (gameStart);
			}
		}
	}
}
