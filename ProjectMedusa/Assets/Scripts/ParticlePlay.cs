using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlay : MonoBehaviour {

	void Effects()
	{
		GetComponent<ParticleSystem> ().Play ();
		GetComponent<AudioSource> ().Play ();
	}
}
