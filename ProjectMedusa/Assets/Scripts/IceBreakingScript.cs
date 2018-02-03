using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBreakingScript : MonoBehaviour {

	Transform ThisTF;

	public GameObject particlePrefab;

	Vector3 startScale;
	Vector3 startPosition;
	Quaternion startRotation;

	GameObject rightHand;
	GameObject leftHand;

	void Start () {
		ThisTF = GetComponent<Transform> ();

		meshCol = GetComponent<Collider> ();

		startScale = ThisTF.localScale;
		startPosition = ThisTF.position;
		startRotation = ThisTF.rotation;

		rightHand = GameObject.Find ("[CameraRig]").GetComponent<SteamVR_ControllerManager> ().right;
		leftHand = GameObject.Find ("[CameraRig]").GetComponent<SteamVR_ControllerManager> ().left;
	}

	[SerializeField]
	bool breaking;
	int breakingFrameCounter;

	float breakingTime;

	bool broken;

	public float respawnTime;
	float breakTime;

	public float timeToBreak;

	void Update () {

		if (breaking) {
			breakingFrameCounter += 1;
			ThisTF.DetachChildren();
			if (breakingFrameCounter > 6) {
				ThisTF.rotation = startRotation;
				ThisTF.position = startPosition;

				ThisTF.RotateAround (ThisTF.position, Vector3.up, Random.Range (-3, 3));
				ThisTF.RotateAround (ThisTF.position, Vector3.right, Random.Range (-3, 3));
				ThisTF.RotateAround (ThisTF.position, Vector3.forward, Random.Range (-3, 3));

				ThisTF.position += Vector3.up * Random.Range (-0.05f, 0.05f);
				ThisTF.position += Vector3.right * Random.Range (-0.05f, 0.05f);
				ThisTF.position += Vector3.forward * Random.Range (-0.05f, 0.05f);

				breakingFrameCounter = 0;
			}
			if (Time.realtimeSinceStartup - breakingTime > timeToBreak) {
				Break ();
				breaking = false;	
			}
		}

		if (broken) {
			if (Time.realtimeSinceStartup - breakTime > respawnTime) {
				ThisTF.localScale = startScale;
				meshCol.enabled = true;
				broken = false;
			}
		}
	}

	Collider meshCol;

	void Break () {
		GameObject newParticles = Instantiate (particlePrefab, ThisTF.position, ThisTF.rotation) as GameObject;

		ThisTF.localScale = Vector3.zero;
		meshCol.enabled = false;

		if (rightHand.GetComponent<GrabBehavior> ().lastGrabObject == ThisTF)
			rightHand.GetComponent<ClickAndDrag> ().LetGo ();
		if (leftHand.GetComponent<GrabBehavior> ().lastGrabObject == ThisTF)
			leftHand.GetComponent<ClickAndDrag> ().LetGo ();

		breakTime = Time.realtimeSinceStartup;

		broken = true;
	}

	void OnTriggerStay (Collider col)
	{
		if (col.tag == "Hand") {
			if (col.gameObject.GetComponent<ClickAndDrag> ().grabbing && !(broken || breaking)) {
				breaking = true;
				breakingTime = Time.realtimeSinceStartup;
				ThisTF.DetachChildren();
				//Break ();
			}
		}
	}
}
