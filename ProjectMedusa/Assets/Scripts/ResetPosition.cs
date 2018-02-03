using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResetPosition : MonoBehaviour {

	[SerializeField]
	GameObject text1, text2;

	SteamVR_TrackedObject trackedObj;
	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

	bool isReseting;
	float resetTime;

	void Update () {
		var device = SteamVR_Controller.Input((int)trackedObj.index);
		if (device.GetPressDown (SteamVR_Controller.ButtonMask.ApplicationMenu)) {
			text1.GetComponent<MeshRenderer> ().enabled = true;
			text2.GetComponent<MeshRenderer> ().enabled = true;
			isReseting = true;
			resetTime = Time.time;
		}
		if (device.GetPressUp (SteamVR_Controller.ButtonMask.ApplicationMenu)) {
			text1.GetComponent<MeshRenderer> ().enabled = false;
			text2.GetComponent<MeshRenderer> ().enabled = false;
			isReseting = false;
		}
		if (isReseting) {
			float dif = Time.time - resetTime;
			if (dif < 1f) {
				text2.GetComponent<TextMesh> ().text = "Three";
			} else if (dif < 2f) {
				text2.GetComponent<TextMesh> ().text = "Two";
			} else if (dif < 3f) {
				text2.GetComponent<TextMesh> ().text = "One";
			} else {
				text1.GetComponent<MeshRenderer> ().enabled = false;
				text2.GetComponent<MeshRenderer> ().enabled = false;
				GetComponent<Transform> ().parent.gameObject.SendMessage ("Respawn");
				isReseting = false;
			}
		}

	}

	/*
	IEnumerator Reset() {
		var device = SteamVR_Controller.Input((int)trackedObj.index);

		yield return new WaitForSeconds(1);
		if (device.GetPress (SteamVR_Controller.ButtonMask.ApplicationMenu)) {
			text2.GetComponent<TextMesh> ().text = "Two";
			yield return new WaitForSeconds(1);
			if (device.GetPress (SteamVR_Controller.ButtonMask.ApplicationMenu)) {
				text2.GetComponent<TextMesh> ().text = "One";
				yield return new WaitForSeconds(1);
				if (device.GetPress (SteamVR_Controller.ButtonMask.ApplicationMenu)) {
					text1.GetComponent<MeshRenderer> ().enabled = false;
					text2.GetComponent<MeshRenderer> ().enabled = false;
					GetComponent<Transform> ().parent.gameObject.SendMessage ("Respawn");
				}
				yield break;
			}
			yield break;
		}
		yield break;
	}
	*/
}
