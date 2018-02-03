using UnityEngine;
using System.Collections;

public class GrabPointVelocity : MonoBehaviour {

	public Vector3 velocity;

	Transform thisTF;

	Vector3 oldpos;
	Vector3 newpos;

	void Start(){
		thisTF = GetComponent<Transform> ();
		oldpos = thisTF.position;
	}

	void Update(){
		newpos = thisTF.position;
		var media =  (newpos - oldpos);
		velocity = media / Time.deltaTime;
		oldpos = newpos;
		newpos = thisTF.position;	
	}
}
