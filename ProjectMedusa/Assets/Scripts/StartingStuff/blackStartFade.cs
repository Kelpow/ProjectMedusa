using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class blackStartFade : MonoBehaviour {


	Material mat;

	[SerializeField]
	AnimationCurve transparency;
	float t;
	// Use this for initialization
	void Start () {
		mat = GetComponent<MeshRenderer> ().material;
		t = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (t == -1)
			return;
		
		mat.color = new Color(mat.color.r,mat.color.g,mat.color.b,transparency.Evaluate(Time.time - t));
		if (Time.time - t > 13f) {
			SceneManager.LoadScene ("ClimbingHeadsMenu");
		}
	}
}
