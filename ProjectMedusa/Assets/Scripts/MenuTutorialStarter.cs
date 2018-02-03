using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTutorialStarter : MonoBehaviour {

	[SerializeField] Checkpoint checkpoint;
	[SerializeField] MenuTutorialDirector tutorial;

	void OnTriggerEnter (Collider col)
	{
		if (col.tag == "Player") {
			checkpoint.ActivateSpawn ();
			col.GetComponent<MenuTutorialDirector> ().states [0].s = true;
		}
	}
}
