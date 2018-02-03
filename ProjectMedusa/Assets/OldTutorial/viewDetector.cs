using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viewDetector : MonoBehaviour {

	Transform fish;
	Transform thisTF;
	[SerializeField] Renderer blackRend;

	public GameObject destroyThis;
	void Start ()
	{
		fish = GameObject.Find ("Fish Carrier").GetComponent<Transform> ();
		thisTF = GetComponent<Transform> ();
	}

	bool lookingAt;
	float lookTime;

	void Update () 
	{
		Vector3 localPos = thisTF.InverseTransformPoint (fish.position);
		if (localPos.x < 0.5f && localPos.x > -0.5f &&
		    localPos.y < 0.5f && localPos.y > -0.5f &&
		    localPos.z < 0.5f && localPos.z > -0.5f) 
		{
			lookingAt = true;
		} else {
			lookingAt = false;
		}

		if (lookingAt && blackRend.material.color.a < 0.1f) {
			Debug.Log ("dick");
			if (Time.time - lookTime > 3f)
				LookedAt ();
		} else {
			lookTime = Time.time;
		}
	}

	void LookedAt()
	{
		GameObject.Find ("Director").SendMessage ("BeginAct", "Fish says Hello");
		Destroy (destroyThis);
	}
}
