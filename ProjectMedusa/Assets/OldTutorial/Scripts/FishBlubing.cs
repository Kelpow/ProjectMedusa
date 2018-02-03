using UnityEngine;
using System.Collections;

public class FishBlubing : MonoBehaviour {

	AudioSource sound;

	[SerializeField] string[] onDirections;
	[SerializeField] string[] offDirections;

	void Start () 
	{
		sound = GetComponent<AudioSource> ();	
	}
	
	public bool isBlubing;

	float blubTime;
	void Update () 
	{
		if (isBlubing) {
			if (Time.time > blubTime) {
				blubTime = Time.time + Random.Range (0.1f, 0.7f);
				sound.pitch = Random.Range (0.9f, 1.9f);
				sound.Play();
			}
		}
	}
		

	public void BlubOn()
	{
		isBlubing = true;
	}

	public void BlubOff()
	{
		isBlubing = false;
	}
	/*
	void ActorEvent(string direction)
	{

		foreach (string name in onDirections) {
			if (name == direction) {
				isBlubing = true;
				Debug.Log ("onBlub: " + direction + "(" + Time.time + ")");
			}
		}
		foreach (string name in offDirections) {
			if (name == direction) {
				isBlubing = false;
				Debug.Log ("offBlub: " + direction + "(" + Time.time + ")");
			}
		}
	}
	//*/
}
