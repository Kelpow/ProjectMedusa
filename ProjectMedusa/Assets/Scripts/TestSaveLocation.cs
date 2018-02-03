using UnityEngine;
using System.Collections;

public class TestSaveLocation : MonoBehaviour {

	public Vector3[] points;
	int x = 0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.X)) {
			
			points [x] = GetComponent<Transform> ().position;
			x++;
			if (x >= points.Length)
				x = 0;
		}
		for (int i = 0; i < points.Length; i++) {
			Willow.DrawCross (points [i]);
		}
	}
}
