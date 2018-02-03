using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[ExecuteInEditMode]
public class ButtonBehavior : MonoBehaviour {

	[SerializeField] UnityEvent buttonDownEvent;
	[SerializeField] UnityEvent buttonUpEvent;

	[Header("Serialized Garbage")]
	[SerializeField] MenuAppearanceBehavior menuAppearance;
	[SerializeField] AudioSource downAudio;	
	[SerializeField] AudioSource upAudio;
	[SerializeField] ButtonPush button;

	void Start () {
		if (!button)
			Debug.LogError ("Button object not assigned", this);
	}
	
	void Update () {
		if (!button)
			return;
		if (menuAppearance && (!menuAppearance.isFull || menuAppearance.isTouching ))
			return;

		if (button.onPushed) {
			buttonDownEvent.Invoke ();
			if (downAudio)
				downAudio.Play ();
		}
		if (button.onRelease) {
			buttonUpEvent.Invoke ();
			if (upAudio)
				upAudio.Play ();
		}
	}
}
