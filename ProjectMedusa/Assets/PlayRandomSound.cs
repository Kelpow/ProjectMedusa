using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayRandomSound : MonoBehaviour {

	[SerializeField] float pitchVariantHigh = 1;
	[SerializeField] float pitchVariantLow = 1;

	[SerializeField] AudioClip[] sounds;

	AudioSource source;

	void Start () {
		source = GetComponent<AudioSource> ();
	}

	public void Play () {
		float pitch = Random.Range (pitchVariantLow, pitchVariantHigh);
		AudioClip clip = sounds [Random.Range (0, sounds.Length)];
		source.pitch = pitch;
		source.PlayOneShot (clip);
	}
}
