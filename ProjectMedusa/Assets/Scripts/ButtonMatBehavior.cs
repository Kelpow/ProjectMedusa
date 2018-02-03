using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMatBehavior : MonoBehaviour {

	Renderer rend;

	[SerializeField] Material onMat;
	[SerializeField] Material offMat;

	[SerializeField] bool isOn;

	void Awake () {
		rend = GetComponent<Renderer> ();
	}

	public void TurnOn()
	{
		GetComponent<Renderer> ().material = onMat;
		isOn = true;
	}

	public void TurnOff()
	{
		GetComponent<Renderer> ().material = offMat;
		isOn = false;
	}

	public void Toggle()
	{
		if (isOn)
			GetComponent<Renderer> ().material = offMat;
		else
			GetComponent<Renderer> ().material = onMat;

		isOn = !isOn;
	}

}
