using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	Transform thisTF;

	void Start(){
		thisTF = GetComponent<Transform> ();
		thisTF.parent = null;
	}

	void HandGrab(Transform hand){
		thisTF.parent = hand;
	}

	void HandRelease()
	{
		thisTF.parent = null;
	}

}
