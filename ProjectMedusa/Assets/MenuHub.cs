using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MenuHub : MonoBehaviour {

	[SerializeField] UnityEvent newEvent;
	[SerializeField] UnityEvent continueEvent;

	public void StartMenu () {
		if (PlayerPrefs.HasKey ("HasSave")) {
			continueEvent.Invoke ();
		} else {
			newEvent.Invoke ();
		}
	}

	public void ContinueGame () {
		SceneManager.LoadScene ("ClimbingHeads");
	}

	public void NewGame () {
		PlayerPrefs.DeleteAll ();
		PlayerPrefs.Save ();
		PlayerPrefs.SetInt ("HasSave", 1);
		PlayerPrefs.Save ();
		SceneManager.LoadScene ("ClimbingHeads");
	}
}
