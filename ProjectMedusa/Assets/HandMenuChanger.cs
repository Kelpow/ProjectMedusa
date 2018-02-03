using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMenuChanger : MonoBehaviour {

	int handLayer = 9;
	int selectLayer = 2;

	SteamVR_TrackedObject trackedObj;
	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

	void Update () {
		var device = SteamVR_Controller.Input((int)trackedObj.index);

		if (device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
			this.gameObject.layer = selectLayer;
		} else {
			this.gameObject.layer = handLayer;
		}
	}
}
