using UnityEngine;
using System.Collections;

public class TutorialSetSpawn : MonoBehaviour {

	/*
	void ActorEvent(string direction)
	{
		if (direction != "hold the reset")
			return;

		GameObject.Find ("[CameraRig]").BroadcastMessage ("SetSpawn", GetComponent<Transform> ().position);
	}
	//*/

	void UpdateSpawn()
	{
		GameObject.Find ("[CameraRig]").BroadcastMessage ("SetSpawn", GetComponent<Transform> ().position);
	}

}
