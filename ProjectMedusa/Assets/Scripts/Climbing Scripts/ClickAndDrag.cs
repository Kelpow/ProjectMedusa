using UnityEngine;
using System.Collections;

public class ClickAndDrag : MonoBehaviour {

	Transform thisTF;
	Transform trackingTF;

	public GameObject grabPointObject;
	Transform objectTF;



	Rigidbody trackingRB;
	GrabPointVelocity velScript;

	Vector3 grabPosition;
	Vector3 trackingPosition;
	Vector3 objectPosition;


	SteamVR_TrackedObject trackedObj;
	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}


	void Start () {
		thisTF = GetComponent<Transform> ();
		trackingTF = thisTF.parent;
		trackingRB = trackingTF.gameObject.GetComponent<Rigidbody> ();
		objectTF = grabPointObject.GetComponent<Transform> ();
		velScript = grabPointObject.GetComponent<GrabPointVelocity> ();
	}

	public bool grabbing;

	public void Grab () {
		grabbing = true;

		grabPosition = trackingTF.InverseTransformPoint(thisTF.position - (thisTF.forward * 0.0769f));
		trackingPosition = trackingTF.position;
		objectPosition = objectTF.position;

		trackingRB.isKinematic = true;
	}
	public void LetGo () {
		if (grabbing) {
			grabbing = false;
			trackingRB.isKinematic = false;
			var device = SteamVR_Controller.Input ((int)trackedObj.index);

			trackingRB.velocity = trackingTF.TransformVector (Vector3.Scale (-device.velocity, throwSpeed)) + velScript.velocity;
		}
	}

	Vector3 throwSpeed = new Vector3(0.5f,0.5f,0.5f);

	void Update () {
		if (grabbing) {
			Vector3 localChange = grabPosition - trackingTF.InverseTransformPoint(thisTF.position - (thisTF.forward * 0.0769f));
			Vector3 worldChange = trackingTF.TransformVector (localChange);
			Vector3 change = worldChange - (objectPosition - objectTF.position);
			trackingTF.position = trackingPosition + change;
		}
	}


	public void SetThrowSpeed(float speed)
	{
		throwSpeed = Vector3.one * speed;
	}
}
