using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuSelect : MonoBehaviour {

	[SerializeField] Material normalMat;
	[SerializeField] Material selectedMat;

	[SerializeField] LayerMask handLayer;
	[SerializeField] LayerMask selectLayer;

	[SerializeField] UnityEvent selectEvent;

	[SerializeField] bool outOfMenuScene = false;

	Transform thisTF;
	Renderer thisRend;
	BoxCollider thisBox;
	void Start () {
		thisTF = GetComponent<Transform> ();
		thisRend = GetComponent<Renderer> ();
		thisBox = GetComponent<BoxCollider> ();
	}
	bool test;
	bool isTouching;

	void Update () {
		Vector3 halfExtents = Vector3.Scale (thisBox.size, thisTF.lossyScale) * 0.5f;

		if (!outOfMenuScene)
			isTouching = Physics.CheckBox (thisTF.TransformPoint (thisBox.center), halfExtents, thisTF.rotation, handLayer);

		if (isTouching)
			thisRend.material = selectedMat;
		else
			thisRend.material = normalMat;

		bool isSelected = Physics.CheckBox (thisTF.TransformPoint (thisBox.center), halfExtents, thisTF.rotation, selectLayer);

		if (outOfMenuScene)
			isSelected = grabbing;

		if (isSelected) {
			selectEvent.Invoke ();	
		}
			
	}

	public void EventInvoke () {
		selectEvent.Invoke ();	
	}

	bool grabbing;

	void OnTriggerStay (Collider col)
	{
		if(outOfMenuScene) {	
			if (col.tag == "Hand") {
				isTouching = true;
				test = true;
				if (col.gameObject.GetComponent<GrabBehavior> ().handMode == 1) {
					grabbing = true;
				} else {	
					grabbing = false;
				}
			} else {
				grabbing = false;
			}
		}
	}

	void LateUpdate()
	{
		if (test) {
			test = false;
		} else {
			isTouching = false;
		}
	}
}