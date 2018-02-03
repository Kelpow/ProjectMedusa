using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPush : MonoBehaviour {

	public bool onPushed;
	public bool pushed;
	public bool onRelease;

	Transform thisTF;
	BoxCollider thisBC;

	Vector3 startPos;
	Vector3 slideDirection;

	[Header("Things to change")]
	[SerializeField] [Range(0.1f,1f)] float maxOutDistance;

	[Header("Serialized Garbage")]	
	[SerializeField] LayerMask fingerMask;

	void Start () {
		thisTF = GetComponent<Transform> ();
		thisBC = GetComponent<BoxCollider> ();

		startPos = thisTF.localPosition;
		slideDirection = thisTF.parent.InverseTransformVector (thisTF.forward).normalized;
	}

	// Update is called once per frame
	void Update () {
		RaycastHit hit;

		Vector3 pointingVector = thisTF.parent.TransformVector (Vector3.forward * maxOutDistance);
		Vector3 halfExtents = Vector3.Scale (thisBC.size, thisTF.lossyScale) * 0.5f;
		Vector3 worldStartPos = thisTF.parent.TransformPoint (startPos);

		if(Physics.CheckBox(worldStartPos, halfExtents, thisTF.rotation, fingerMask)) {
			thisTF.localPosition = startPos;

			if (!pushed)
				onPushed = true;
			else
				onPushed = false;
			
			pushed = true;
			onRelease = false;
		} else if (Physics.BoxCast(worldStartPos, halfExtents, pointingVector, out hit,thisTF.rotation, pointingVector.magnitude, fingerMask)) {
			thisTF.localPosition = startPos + thisTF.parent.InverseTransformVector(thisTF.forward * hit.distance);

			if(pushed)
				onRelease = true;
			else
				onRelease = false;

			pushed = false;
			onPushed = false;
		} else {
			thisTF.localPosition = startPos + Vector3.forward * maxOutDistance;

			if(pushed)
				onRelease = true;
			else
				onRelease = false;
			
			onPushed = false;
			pushed = false;
		}
	}
}
