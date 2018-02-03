using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiofade : MonoBehaviour {

	AudioSource sound;

	[SerializeField]
	AnimationCurve volume;

	float t;
	// Use this for initialization
	void Start () {
		sound = GetComponent<AudioSource> ();
		t = Time.time;
	}

	// Update is called once per frame
	void Update () {
		if (t == -1)
			return;

		sound.volume = volume.Evaluate(Time.time - t);
		/*if (Time.time - t > 13f) {
			SceneManager.LoadScene ("ClimbingHeads");
		}*/
	}
}
