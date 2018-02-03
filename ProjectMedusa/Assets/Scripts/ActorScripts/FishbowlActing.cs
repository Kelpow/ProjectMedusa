using UnityEngine;
using System.Collections;

public class FishbowlActing : MonoBehaviour {

	Transform thisTF;

	[SerializeField] float shakingSpeed;
	[SerializeField] float shakingScale;
	float shakingTime;
	bool isShaking = true;

	void Start()
	{
		thisTF = GetComponent<Transform> ();
	}

	void ActorEvent(string direction)
	{
		switch (direction) 
		{
		case "Hey!":
			isShaking = true;
			break;
		case "You!":
			break;
		}
	}



	void Update ()
	{
		if (isShaking) {
			thisTF.rotation = Quaternion.LookRotation (Vector3.forward, Vector3.up * 2 + Vector3.right * shakingScale * Mathf.Sin (Time.time * shakingSpeed));
		}
	}
		
}
