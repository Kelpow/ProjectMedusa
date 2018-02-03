using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class directorTriggerSelf : MonoBehaviour {

	[SerializeField] GameObject blackFade;
	/*
	void ActorEvent(string direction)
	{
		switch (direction) {
		case "start W&T":
			this.SendMessage ("BeginAct", "Lets walk and talk");
			break;
		case "Been here?":
			if (PlayerPrefs.HasKey ("finishedTutorial")) {
				this.SendMessage ("BeginAct", "You look familiar");
			} else {
				this.SendMessage ("BeginAct", "No body explanation");
			}
			break;
		case "get out of here loading":
			blackFade.SetActive (true);
			StartCoroutine (LeaveLevel());
			break;
		case "get out of here":
			blackFade.SetActive (true);
			PlayerPrefs.DeleteAll ();
			PlayerPrefs.Save ();
			PlayerPrefs.SetInt ("finishedTutorial", 1);
			StartCoroutine (LeaveLevel());
			break;
		}
	}
	//*/
	public void BeenHere()
	{
		if (PlayerPrefs.HasKey ("finishedTutorial")) {
			this.SendMessage ("BeginAct", "You look familiar");
		} else {
			this.SendMessage ("BeginAct", "No body explanation");
		}
	}

	public void StartWT()
	{
		this.SendMessage ("BeginAct", "Lets walk and talk");
	}

	public void GetOutOfHereLoad()
	{
		blackFade.SetActive (true);
		StartCoroutine (LeaveLevel());
	}

	public void GetOutOfHereClearData()
	{
		blackFade.SetActive (true);
		PlayerPrefs.DeleteAll ();
		PlayerPrefs.Save ();
		PlayerPrefs.SetInt ("finishedTutorial", 1);
		StartCoroutine (LeaveLevel());
	}

	IEnumerator LeaveLevel()
	{
		yield return new WaitForSeconds (6f);
		SceneManager.LoadScene ("ClimbingHeads");
	}
}
