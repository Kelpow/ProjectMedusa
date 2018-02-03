using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadSpeed : MonoBehaviour {

	public float velocity;

	Transform thisTF;

	[SerializeField] Vector4[] pos;

	Vector3 oldpos;
	Vector3 newpos;

	void Start(){
		thisTF = GetComponent<Transform> ();
		oldpos = thisTF.position;
		pos = new Vector4[6];
	}

	void Update(){

		float time = 0f;
		float distance = 0f;
		Vector3 change;
		for (int q = pos.Length - 1; q > 0; q--) //copy all positions down 1
		{
			pos [q] = pos [q - 1];
		}
		pos [0] = MakeTimeVector (thisTF.position);
	
		for (int q = 0; q < pos.Length - 1; q++) {
			change = MakeTimeVector (pos [q]) - MakeTimeVector (pos [q + 1]);
			distance += change.magnitude;
			time += pos [q].w;
		}

		velocity = distance / time;
	}

	Vector4 MakeTimeVector(Vector3 vect)
	{
		return new Vector4 (vect.x, vect.y, vect.z, Time.deltaTime);
	}
	Vector3 MakeTimelessVector(Vector4 vect)
	{
		return new Vector3 (vect.x, vect.y, vect.z);
	}
}
