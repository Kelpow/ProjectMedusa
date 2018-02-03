using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CreditsLoader : MonoBehaviour {

	public UnityEvent loadEvent;
	public bool loaded;
	public GameObject creditsButtonL;
	public GameObject creditsButtonR;

	void Start () {
		if (PlayerPrefs.HasKey ("hasCreditsButton")) {
			creditsButtonL.SetActive (true);
			creditsButtonR.SetActive (true);
		}
	}
	 
	public void Load () {
		if (!loaded) {
			loadEvent.Invoke ();
			loaded = true;
		}
	}

	public void ButtonActivate () {
		PlayerPrefs.SetInt ("hasCreditsButton", 1);
		creditsButtonL.SetActive (true);
		creditsButtonR.SetActive (true);
		loaded = true;
	}
}
