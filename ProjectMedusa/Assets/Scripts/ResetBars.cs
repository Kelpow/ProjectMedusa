using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBars : MonoBehaviour {

	[SerializeField] Sprite[] bars;

	public int bar;

	SpriteRenderer sr;
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		sr.sprite = bars[bar];
	}
}
