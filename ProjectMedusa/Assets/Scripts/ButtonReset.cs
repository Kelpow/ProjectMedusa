using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonReset : MonoBehaviour {

	[SerializeField] GameObject player;
	[SerializeField] ResetBars bar;
	bool isReseting;
	float resetTime;
	[HideInInspector] public bool hasReset;

	float timeToReset = 2f;

	void Update () {
		if (isReseting) {
			float t = Time.time - resetTime;
			if (t > timeToReset) {
				bar.bar = 4;
				player.SendMessage("Respawn");
				hasReset = true;
				isReseting = false;
			} else if (t > (timeToReset / 3) * 2) {
				bar.bar = 3;
			} else if (t > (timeToReset / 3) * 1) {
				bar.bar = 2;
			} else {
				bar.bar = 1;
			}
		} else {
			if(hasReset)
			{
				bar.bar = 4;
			} else {
				bar.bar = 0;
			}
		}
	}

	public void Begin ()
	{
		Debug.Log ("Begin");
		isReseting = true;
		resetTime = Time.time;
	}
	public void Stop ()
	{
		isReseting = false;
		hasReset = false;
	}
}

