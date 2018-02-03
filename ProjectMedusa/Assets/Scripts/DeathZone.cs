using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(GetComponent<MeshRenderer>());
	}

	[SerializeField]
	bool isFallZone;

	void OnTriggerEnter(Collider col){

		if (isFallZone) {
			col.gameObject.SendMessage ("RespawnOnCollision");
		} else {
			col.gameObject.SendMessage ("Respawn");
		}
	}

}
