using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScrollController : MonoBehaviour {



	public float position;
	[Header("Things to Change")]
	[SerializeField] float spinSpeedLimit;
	[SerializeField] float touchSpeedMultiplier;

	[Header("Serialized Garbage")]
	[SerializeField] MenuInteractionController interactions;
	[SerializeField] MenuAppearanceBehavior appearance;

	void Start () {
		
	}

	void Update () {
		if (!appearance.isFull)
			return;
	}
}
