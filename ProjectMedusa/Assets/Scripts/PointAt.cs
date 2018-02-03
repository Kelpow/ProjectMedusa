using UnityEngine;
using System.Collections;

public class PointAt : MonoBehaviour {

	Transform thisTF;

	public Transform target;



	// Use this for initialization
	void Start () {
		thisTF = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		thisTF.LookAt (target);
		thisTF.localScale = new Vector3(0.1f, 0.1f, Vector3.Distance (thisTF.position, target.position));
	}
}
