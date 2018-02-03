using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHEATSGALORE : MonoBehaviour {

	public Willow.Dupe.Cheat[] cheats;

	void Update () {
		if (Willow.Dupe.Cheating ()) {
			string input = Willow.Dupe.input;
			Debug.Log ("|" + input + "|");
			foreach (Willow.Dupe.Cheat cheat in cheats) {
				if (input == cheat.cheatCode)
					cheat.Toggle ();
			}
		}
	}

	public void CheatOverride (string code)
	{
		foreach (Willow.Dupe.Cheat cheat in cheats) {
			if (code == cheat.cheatCode)
				cheat.Toggle ();
		}
	}

	public void FlipCastle ()
	{
		GetComponent<Transform> ().RotateAround (GetComponent<Transform> ().TransformPoint (GetComponent<SphereCollider> ().center), Vector3.forward, 180f);
		Physics.gravity = -Physics.gravity;
	}

	public void GravitySet (float gravity)
	{
		Physics.gravity = Vector3.down * gravity;
	}
}
