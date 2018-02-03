using UnityEngine;
using System.Collections;

public class FishLookat : MonoBehaviour { 

	Transform thisTF;
	Transform playerFace;
	Transform target;
	void Start () 
	{
		thisTF = GetComponent<Transform> ();

		playerFace = GameObject.Find ("Camera (eye)").GetComponent<Transform> ();
	}

	void Update () 
	{
		Vector3 difference = playerFace.position - thisTF.position;
		Quaternion newRot = Quaternion.LookRotation (difference.Flatten());
		thisTF.rotation = Quaternion.Lerp (thisTF.rotation, newRot, 0.01f);
		//thisTF.LookAt(thisTF.position + difference.Flatten());
	}
}
