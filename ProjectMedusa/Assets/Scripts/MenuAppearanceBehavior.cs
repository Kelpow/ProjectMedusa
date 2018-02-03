using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAppearanceBehavior : MonoBehaviour {

	Transform thisTF;
	BoxCollider thisBC;

	public bool isTouching;
	public bool isOpening;
	public float size;

	[Header("Things to Change")]
	//[SerializeField] float heightToOpen;
	[SerializeField] bool closeWhenHandNotOpen;

	[Header("Public Variables")]
	public bool isFull;

	[Header("Serialized Garbage")]
	[SerializeField] Transform touch;
	[SerializeField] Transform menuBase;
	[SerializeField] LayerMask fingerMask;
	[SerializeField] ParticleSystem particles;
	[SerializeField] GrabBehavior hand;
	[SerializeField] ButtonCycle cycle;

	void Start () {
		thisTF = GetComponent<Transform> ();
		thisBC = GetComponent<BoxCollider> ();

		menuBase.localScale = Vector3.one * 0.001f;
	}
	
	// Update is called once per frame
	void Update () {
		if(thisBC)
		{
			Vector3 halfExtents = Vector3.Scale (thisBC.size, thisTF.lossyScale) * 0.5f;

			if (isTouching)
				halfExtents = Vector3.Scale (halfExtents, Vector3.one + Vector3.forward);

			bool checkBox = Physics.CheckBox (thisTF.TransformPoint (thisBC.center), halfExtents, thisTF.rotation, fingerMask);
			/*
			if (!isOpening && !isFull) {
				size = 0;
			}
			if (!isTouching && checkBox && !isFull) {
				isTouching = true;
				isOpening = !isOpening;
			} else if (!checkBox) {
				isTouching = false;
			}

			if (isOpening) {
				float height = Vector3.Distance(thisTF.position, touch.position);
				size = Mathf.Clamp (height / heightToOpen, 0.001f, 1f);
				if (height / heightToOpen >= 1f) {
					isFull = true;
					isOpening = false;
				}
			}
			//*/
			if (!checkBox)
				isTouching = false;
			else if (!isFull&&!isTouching) {
				Open ();
			}
		}
			
		if (closeWhenHandNotOpen) {
			if (hand) {
				if (hand.handMode != 0) {
					if (cycle) {
						cycle.InvokeSpecific (0);
					} else {
						Debug.LogError ("Failed no cycle", this);
					}
				}
				
			} else {
				Debug.LogError ("Failed no hand", this);
			}
		}

		size = isFull ? 1f : 0f;

		menuBase.localScale = Vector3.one * size;
	}
	public void Close()
	{
		if (isFull)
			particles.Play ();
		size = 0f;
		if (thisBC)
			isTouching = true;
		isOpening = false;
		isFull = false;
	}

	public void Open()
	{
		if (thisBC)
			isTouching = true;
		isFull = true;
		particles.Play ();
	}

}
