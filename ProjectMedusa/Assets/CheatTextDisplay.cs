using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatTextDisplay : MonoBehaviour {

	void Update () 
	{
		GetComponent<Text> ().text = Willow.Dupe.input;
	}
}
