using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuTutorialAction : MonoBehaviour {

	[SerializeField]string scriptName;
	[ContextMenu("Rename")] void Naming() { }

	[SerializeField]MenuTutorialDirector director;
	[SerializeField]UnityEvent activate;
	[SerializeField]UnityEvent deactivate;

	[Header("Required States")]
	[SerializeField] Tutorial.State[] states;

	[Header("Excluded States")]
	[SerializeField] Tutorial.State[] excluded;

	[ContextMenu("Populate states")]
	void Populate()
	{
		states = director.states;
	}
	[ContextMenu("Populate exclusions")]
	void PopulateExclusions()
	{
		excluded = new Tutorial.State[states.Length];

		for(int q = 0; q < excluded.Length; q++) {
			excluded [q] = new Tutorial.State ();
			excluded [q].name = states[q].name;
		}
	}

	void Start () {
		if (excluded.Length == 0)
		{
			PopulateExclusions ();
		}
	}

	bool hasActed;

	void Update () {
		bool s = CheckStates ();
		if (!hasActed && s) {
			activate.Invoke ();
			Debug.Log ("invoked " + scriptName, this);
			hasActed = true;
		} else if (hasActed && !s) {
			deactivate.Invoke ();
			hasActed = false;
		}
	}
	bool CheckStates()
	{
		for (int q = 0; q < states.Length; q++) {
			if ((states [q].s != director.states [q].s) && !excluded[q].s) {
				return false;
			}
		}
		return true;
	}
}
