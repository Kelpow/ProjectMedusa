using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInteractionController : MonoBehaviour {

	Transform thisTF;

	[Header("Things to Change")]

	[Header("Public Variables")]
	public float velocity;
	public float change;
	public bool isTouching;
	 
	Vector3 fingerpos;

	[Header("Serialized Garbage")]
	[SerializeField] MenuAppearanceBehavior appearance;
	[SerializeField] Transform touch;
	[SerializeField] LayerMask menuMask;

	void Update () {

		if (!appearance.isFull)
			return;

		/* code for scrolling 
		isTouching = Willow.PointInBoxCollider(touch.position, GetComponent<BoxCollider>());

		change = thisTF.InverseTransformPoint(touch.position).y - fingerpos.y;
		fingerpos = thisTF.InverseTransformPoint (touch.position);
		//*/

	}

	void Start()
	{
		thisTF= GetComponent<Transform>();
		fingerpos = thisTF.InverseTransformPoint(touch.position);
	}

}
