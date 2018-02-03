using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTutorialVibrate : MonoBehaviour {

	SteamVR_TrackedObject trackedObj;
	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

	void Start () {
		
	}

	[SerializeField] float delay;
	[SerializeField] float length;
	[SerializeField] ushort strength;
	public bool shouldVibrate = true;
	float vibrateTime;
	bool hasStarted;
	public void StartVibrate () { shouldVibrate = true; hasStarted = true; vibrateTime = Time.time + 0.2f; }
	public void StartVibrateDelayed () { shouldVibrate = true; hasStarted = true; vibrateTime = Time.time + delay; }
	public void StopVibrate () { if (hasStarted) return; shouldVibrate = false; }

	void Update () {
		var device = SteamVR_Controller.Input((int)trackedObj.index);



		if (shouldVibrate && Time.time > vibrateTime) {
			device.TriggerHapticPulse (strength);
			if(Time.time > vibrateTime + length)
				vibrateTime = Time.time + delay;
		}
	}

	void LateUpdate()
	{
		hasStarted = false;
	}
}
