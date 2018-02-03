using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonCycle : MonoBehaviour {

	[SerializeField] UnityEvent[] events;

	public int currentEvent;

	[SerializeField] ButtonCycle mirroredButton;

	void Start () {
		
	}
	
	public void InvokeNext ()
	{
		Debug.Log ("Next");
		currentEvent++;
		if (currentEvent >= events.Length)
			currentEvent = 0;
		events [currentEvent].Invoke ();

		if(mirroredButton)
			mirroredButton.InvokeMirrored (currentEvent);
	}
	public void InvokeSpecific (int eventNumber)
	{
		if ((currentEvent >= events.Length) || currentEvent < 0)
			Debug.Log ("Failed Button: invalid event number");
		else
			currentEvent = eventNumber;
		events [currentEvent].Invoke ();

		if (mirroredButton)
			mirroredButton.InvokeMirrored (currentEvent);
		
	}

	public void InvokeMirrored (int eventNumber)
	{
		if ((currentEvent >= events.Length) || currentEvent < 0)
			Debug.Log ("Failed Mirrored Button: invalid event number");
		else
			currentEvent = eventNumber;
		events [currentEvent].Invoke ();
	}
}
