using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCycleSaver : MonoBehaviour {

	[SerializeField] int defaultCycle;

	ButtonCycle cycle;

	void Start () 
	{
		cycle = GetComponent<ButtonCycle> ();
		if (PlayerPrefs.HasKey (this.gameObject.name + " savedCycle")) {
			cycle.InvokeSpecific (PlayerPrefs.GetInt (this.gameObject.name + " savedCycle"));
		} else {
			PlayerPrefs.SetInt (this.gameObject.name + " savedCycle", defaultCycle);
			cycle.InvokeSpecific (defaultCycle);
		}
	}
	

	void OnApplicationQuit () 
	{
		PlayerPrefs.SetInt (this.gameObject.name + " savedCycle", cycle.currentEvent);
	}
}
