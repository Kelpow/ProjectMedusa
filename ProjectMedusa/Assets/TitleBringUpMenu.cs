using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TitleBringUpMenu : MonoBehaviour {

	[SerializeField] UnityEvent doThing;


	public void InvokeEvent ()
	{
		doThing.Invoke ();
	}
}
