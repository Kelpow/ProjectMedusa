using UnityEngine;
using System.Collections;

public class endOfResetTut : MonoBehaviour {

	void OnTriggerEnter()
	{
		GameObject.Find ("Director").SendMessage ("BeginAct", "Thats it");
	}
}
