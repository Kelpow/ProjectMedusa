using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationControl : MonoBehaviour {

	[SerializeField]
	public int rotateMode;

	void LateUpdate () {
		switch (rotateMode) {
		case 0:
			return;
			break;
		case 1:
			SnapTurning ();
			return;
			break;
		case 2:
			SmoothTurning ();
			return;
			break;
		default:
			Debug.Log ("I swear to Humanity Aaron, if this runs...");
			break;
		}
	}

	public void SetRotateMode(int mode)
	{
		rotateMode = mode;
	}

	SteamVR_TrackedObject trackedObj;
	void Awake() {trackedObj = GetComponent<SteamVR_TrackedObject>();}

	float snapDegrees = 15f;
	float snapTime;
	float snapDelay = 0.25f;

	void SnapTurning ()
	{
		var device = SteamVR_Controller.Input ((int)trackedObj.index);
		bool toSnap = false;
		Vector2 vect = device.GetAxis ();

		if (vect.x > 0.3f || vect.x < -0.3f) {
			if (snapTime + snapDelay < Time.time)
				toSnap = true;
		} else {
			snapTime = 0f;
		}

		if (toSnap) {
			if(vect.x > 0)
				Rotate (snapDegrees);
			else
				Rotate (-snapDegrees);
			snapTime = Time.time;
		}
	}

	float smoothSpeed = 60f;

	void SmoothTurning ()
	{
		var device = SteamVR_Controller.Input ((int)trackedObj.index);
		Vector2 vect = device.GetAxis ();

		if (vect.x > 0.3f) {
			Rotate (smoothSpeed * Time.deltaTime);
		} else if (vect.x < -0.3f) {
			Rotate (-smoothSpeed * Time.deltaTime);
		}
	}

	[SerializeField] Transform cameraRig;
	[SerializeField] Transform head;
	[SerializeField] ClickAndDrag rightController;
	[SerializeField] ClickAndDrag leftController;

	void Rotate (float degrees)
	{
		Vector3 rotatePoint;
		int hand;

		if (rightController.grabbing) {
			hand = 1;
			rotatePoint = rightController.GetComponent<Transform>().position;
			rightController.LetGo ();
		} else if (leftController.grabbing) {
			hand = 2;
			rotatePoint = leftController.GetComponent<Transform>().position;
			leftController.LetGo ();
		} else {
			hand = 0;
			rotatePoint = head.position;
		}

		cameraRig.RotateAround (rotatePoint, Vector3.Scale(Vector3.down, Physics.gravity), degrees);

		if (hand == 0)
			return;
		if (hand == 1)
			rightController.Grab ();
		else
			leftController.Grab ();
	}
}
