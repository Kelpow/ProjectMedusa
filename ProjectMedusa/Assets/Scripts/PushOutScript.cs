using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushOutScript : MonoBehaviour {

	Vector3[] vectors;


	[SerializeField] float radius;
	[SerializeField] LayerMask groundMask;
	[SerializeField] ClickAndDrag rightHand;
	[SerializeField] ClickAndDrag leftHand;
	GrabBehavior rightGrab;
	GrabBehavior leftGrab;

	SphereCollider rightSphere;
	SphereCollider leftSphere;
	Transform rightTransform;
	Transform leftTransform;

	[SerializeField] Transform player;

	bool rightHandIsPushed;
	bool leftHandIsPushed;
	Vector3 origin;

	void Start()
	{
		vectors = Willow.PointsOnSphere (150);
		rightGrab = rightHand.GetComponent<GrabBehavior> ();
		leftGrab = leftHand.GetComponent<GrabBehavior> ();

		rightSphere = rightHand.GetComponent<SphereCollider> ();
		rightTransform = rightHand.GetComponent<Transform> ();
		leftSphere = leftHand.GetComponent<SphereCollider> ();
		leftTransform = leftHand.GetComponent<Transform> ();
	}

	void Update()
	{
		Vector3 start = GetComponent<Transform> ().position;
		RaycastHit hit;
		Vector3 closestHit = Vector3.zero;
		float distanceOfHit = radius;
		bool hasHit = false;

		/*
		if (!rightHand.grabbing)
			rightHandIsPushed = false;
		if (!leftHand.grabbing)
			leftHandIsPushed = false;
		
		if ((rightHandIsPushed || leftHandIsPushed) && !(Physics.CheckSphere (start, radius, groundMask)))
		{
			Returning ();
			return;
		}
		*/
		for (int q = 0; q < vectors.Length; q++) {
			Debug.DrawRay (start, vectors [q] * distanceOfHit, Color.black);
			if (Physics.Raycast (start, vectors [q], out hit, distanceOfHit, groundMask)) {
				distanceOfHit = hit.distance;
				closestHit = vectors [q];
				Debug.DrawRay (start, vectors [q] * distanceOfHit, Color.red);
				hasHit = true;
			}
		}
		if (hasHit) {// if head is in the wall push out
			PushBack (distanceOfHit, closestHit);
			if (rightHand.grabbing) {
				rightHand.LetGo ();

				/*rightHand.Grab ();
				if (!rightHandIsPushed)
					origin = rightHand.GetComponent<Transform> ().position;
				rightHandIsPushed = true;*/
				if (Physics.CheckSphere(rightTransform.TransformPoint(rightSphere.center), rightSphere.radius, rightGrab.grabMask)) {
					rightHand.Grab ();
				} 
			} else if (leftHand.grabbing) {
				leftHand.LetGo ();

				/*leftHand.Grab ();
				if (!leftHandIsPushed)
					origin = leftHand.GetComponent<Transform> ().position;
				leftHandIsPushed = true;*/
				if (Physics.CheckSphere(leftTransform.TransformPoint(leftSphere.center), leftSphere.radius, leftGrab.grabMask)) {
					leftHand.Grab ();
				}
			}
		} /*else if (rightHandIsPushed || leftHandIsPushed)  { // if the head is not in a wall and hand is not in original position

			ClickAndDrag hand = rightHandIsPushed? rightHand : leftHand;
			Vector3 handPosition = hand.GetComponent<Transform>().position;
			Vector3 changeVector = origin - handPosition;



		}*/
	} 

	void Returning ()
	{
		ClickAndDrag hand = rightHandIsPushed? rightHand : leftHand;
		Vector3 handPosition = hand.GetComponent<Transform>().position;
		Vector3 changeVector = origin - handPosition;

		Vector3 start = GetComponent<Transform> ().position;
		RaycastHit hit;
		Vector3 closestHit = Vector3.zero;
		float distanceOfHit = radius;

		player.position += changeVector.normalized * 0.5f * Time.deltaTime;

		for (int q = 0; q < vectors.Length; q++) {
			if (Physics.Raycast (start, vectors [q], out hit, distanceOfHit, groundMask)) {
				distanceOfHit = hit.distance;
				closestHit = vectors [q];
				//Debug.DrawRay (start, vectors [q] * distanceOfHit, Color.red);
			}
		}

		PushBack (distanceOfHit, closestHit);
		hand.LetGo ();
		hand.Grab ();
	}

	void PushBack(float dist, Vector3 vect)
	{
		player.position -= (radius - dist) * vect;
	}
}

