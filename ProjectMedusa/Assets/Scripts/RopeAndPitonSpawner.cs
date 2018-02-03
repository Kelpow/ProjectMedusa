using UnityEngine;
using System.Collections;

public class RopeAndPitonSpawner : MonoBehaviour {

	[SerializeField] GameObject ropeBall;
	[SerializeField] GameObject rope;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt (gameObject.name) == 1) {
			Drop ();
		}
	}

	void Drop ()
	{
		ropeBall.SetActive (false);
		rope.SetActive (true);
		PlayerPrefs.SetInt (gameObject.name, 1);
		PlayerPrefs.Save();
	}

	// Update is called once per frame
	void Update () {
	
	}
}
