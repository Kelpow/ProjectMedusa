using UnityEngine;
using System.Collections;

public class DestroySelf : MonoBehaviour {
	[SerializeField]
	float t;
	// Use this for initialization
	void Start () {
		StartCoroutine (Die ());
	}
	
	IEnumerator Die(){
		yield return new WaitForSeconds (t);
		Destroy (this.gameObject);
	}
}
