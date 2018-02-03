using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpin : MonoBehaviour {

	public float offset;
	[SerializeField] MenuScrollController menu;
	public float position;
	Transform thisTF;
	void Start () {
		thisTF = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		thisTF.localPosition = new Vector3 (0f, Mathf.Sin (offset + position), Mathf.Cos (offset + position)) * 0.2f;
		thisTF.LookAt(thisTF.parent, thisTF.parent.up);
	}
}
