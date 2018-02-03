using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGrabChange : MonoBehaviour {

	public void MakeGrabbable ()
	{
		this.gameObject.layer = 8;
	}
}
