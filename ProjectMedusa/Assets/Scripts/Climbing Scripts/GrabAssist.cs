using UnityEngine;
using System.Collections;

public class GrabAssist : MonoBehaviour {
	Rigidbody parentRB;

	GrabBehavior grabScript;
	ClickAndDrag moveScript;

	SteamVR_TrackedObject trackedObj;
	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

	void Start()
	{
		
	}

	public Vector3 maxMag;


	float lastVelocityCheck = 0f;
	const float TIMEBETWEENCHECKS = 0.009f;
	void Update()
	{
		if (moveScript.grabbing) {
			if (lastVelocityCheck == 0f) { // this is for the first grab

			} else if (Time.time - lastVelocityCheck > TIMEBETWEENCHECKS) {

			}
		} else {
			lastVelocityCheck = 0f;
		}
	}



	Vector3 listvel1, listvel2, listvel3, listvel4, listvel5;
	void UpdateVelocityList(Vector3 vel)
	{
		listvel2 = listvel1;
		listvel3 = listvel2;
		listvel4 = listvel3;
		listvel5 = listvel4;

	}
}
