using UnityEngine;
using System.Collections;

public class SkyboxRotate : MonoBehaviour {

	public Material sky;
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update()
	{
		sky.SetFloat("_Rotation", Time.time * 0.3f);

	}   
}
