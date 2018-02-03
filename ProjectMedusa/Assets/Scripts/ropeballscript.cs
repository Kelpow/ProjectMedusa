using UnityEngine;
using System.Collections;

public class ropeballscript : MonoBehaviour {

	public GameObject rope;

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Hand") {
			this.GetComponent<Transform> ().parent.SendMessage ("Drop");
		}
	}
}
