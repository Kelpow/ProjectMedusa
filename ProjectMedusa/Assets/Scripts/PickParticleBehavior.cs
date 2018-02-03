using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickParticleBehavior : MonoBehaviour {

	ParticleSystem part;
	Transform player;

	void Start () {
		part = GetComponent<ParticleSystem> ();
		player = GameObject.Find ("Head").GetComponent<Transform>();
	}
	[ContextMenu("set")]
	void Spawn()
	{
		player = GameObject.Find ("Head").GetComponent<Transform>();
		GetComponent<Transform> ().parent = null;
		GetComponent<Transform> ().LookAt (player);
		part.Play ();

		StartCoroutine (Destory ());
	}

	bool IsPlaying()
	{
		return part.isPlaying;
	}

	IEnumerator Destory()
	{
		while (part.isPlaying) {
			yield return 0;
		}
		GameObject.Destroy (this.gameObject);
	}
}
