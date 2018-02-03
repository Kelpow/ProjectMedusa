using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickTutorialStart : MonoBehaviour {
	[SerializeField]
	GameObject[] picks;

	[SerializeField]
	GameObject[] primePicks;

	[SerializeField]
	GameObject[] particles;

	[SerializeField]
	GameObject[] tutorialStuffs;

	[SerializeField]
	MenuTutorialVibrate vibrate;

	[SerializeField]
	GrabBehavior rightHand;
	[SerializeField]
	GrabBehavior leftHand;

	[SerializeField]
	GameObject pickHolder;
	void Start()
	{
		if (PlayerPrefs.HasKey ("gottenPicks")) {
			SelfDestruct ();
			pickHolder.SetActive (true);
		} else {
			pickHolder.SetActive (false);
		}
	}

	void OnTriggerEnter (Collider col) {
		if (col.tag == "Hand") {
			Begin ();
		}
	}

	bool hasBegun;

	void Begin ()
	{
		hasBegun = true;

		Destroy (GetComponent<BoxCollider> ());

		pickHolder.SetActive (true);
		PlayerPrefs.SetInt ("gottenPicks", 1);

		foreach (GameObject stuff in tutorialStuffs) {
			stuff.SetActive (true);
		}

		vibrate.enabled = true;

		//picks effects
		foreach (GameObject pick in picks) {
			Destroy (pick);
		}
		foreach (GameObject part in particles) {
			part.GetComponent<ParticleSystem> ().Play ();
		}
	}

	void Update ()
	{
		if (hasBegun) {
			if (rightHand.holdingPick || leftHand.holdingPick)
				SelfDestruct ();
		}
	}

	void SelfDestruct()
	{
		foreach (GameObject obj in tutorialStuffs) {
			Destroy (obj);
		}
		foreach (GameObject obj in primePicks) {
			Destroy (obj);
		}
		Destroy (vibrate);

		Destroy (this.gameObject);
	}
}
