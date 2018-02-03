using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MenuTutorialDirector : MonoBehaviour {


	[Header("Public States")]
	public Tutorial.State[] states;

	[Header("Serialized Garbage")]
	[SerializeField] MenuAppearanceBehavior rightMenuApp;
	[SerializeField] MenuAppearanceBehavior leftMenuApp;
	[SerializeField] HandAnimate rightHandAnim;
	[SerializeField] HandAnimate leftHandAnim;
	[SerializeField] ButtonReset rightReset;
	[SerializeField] ButtonReset leftReset;

	int hasStarted, rightPointing, leftPointing, rightMenu, leftMenu, hasReset;
	void Start () {

		for (int q = 0; q < states.Length; q++) {
			switch (states [q].name) {
			case "hasStarted":
				hasStarted = q;
				break;
			case "rightPointing":
				rightPointing = q;
				break;
			case "leftPointing":
				leftPointing = q;
				break;
			case "rightMenu":
				rightMenu = q;
				break;
			case "leftMenu":
				leftMenu = q;
				break;
			case "hasReset":
				hasReset = q;
				break;
			}
		}
	}

	void Update () {

		states [rightPointing].s = (rightHandAnim.currentMesh == 3); //magic number for pointing mesh
		states [leftPointing].s = (leftHandAnim.currentMesh == 3);

		states [rightMenu].s = rightMenuApp.isFull;
		states [leftMenu].s = leftMenuApp.isFull;

		if (rightReset.hasReset || leftReset.hasReset) {
			states [hasReset].s = true;
			PlayerPrefs.SetInt ("hasFinishedMenuTutorial", 1);
		}

		/*garbage fix*/ if (states [rightPointing].s) states[leftPointing].s = false; /* Using these to favor the right hand cause I need to favor something ¯\_(ツ)_/¯ */ if (states [rightMenu].s) states[leftMenu].s = false;
	}

	void LateUpdate () {
		if (states [hasReset].s)
			SelfDestruct ();
	}

	[Header("Related Objects to Destroy")]
	[SerializeField]
	Object[] toDestroy;

	void SelfDestruct () {
		foreach (Object obj in toDestroy) {
			Destroy (obj);
		}
	}
}

namespace Tutorial {
	[System.Serializable]
	public class State {
		public string name;
		public bool s;
	}
}
