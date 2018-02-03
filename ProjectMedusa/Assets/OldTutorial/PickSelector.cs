using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickSelector : MonoBehaviour {

	void PickRed()
	{
		GameObject.Find ("Director").SendMessage ("GetOutOfHereLoad");
	}

	void PickBlue()
	{
		GameObject.Find ("Director").SendMessage ("GetOutOfHereClearData");
	}
}
