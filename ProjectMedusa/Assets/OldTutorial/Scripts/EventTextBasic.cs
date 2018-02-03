using UnityEngine;
using System.Collections;

public class EventTextBasic : MonoBehaviour {

	[SerializeField] string eventName; 
	Renderer rend;

	void Start()
	{
		rend = GetComponent<Renderer> ();
	}

	public void TurnOn()
	{
		rend.enabled = true;
	}
	public void TurnOff()
	{
		rend.enabled = false;
	}

	/*
	void ActorEvent(string direction)
	{
		
		if (direction == eventName) {
			rend.enabled = true;
		}else {
			rend.enabled = false;
		}
	}
	//*/
}
