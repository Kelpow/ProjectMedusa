using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : MonoBehaviour {

	TextMesh text;

	int frame = 0;

	void Start () {
		text = GetComponent<TextMesh> ();
	}

	void Update () {
		frame++;
		if (frame >= 10) {
			text.text = Mathf.RoundToInt (1f / Time.deltaTime).ToString();
			frame = 0;
		}

		
	}
}
