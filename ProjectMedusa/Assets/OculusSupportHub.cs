using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OculusSupportHub : MonoBehaviour {

	[SerializeField] UnityEvent oculusSetup;
	[SerializeField] UnityEvent viveDestroy;

	void LateUpdate ()
	{
		if (QualitySettings.GetQualityLevel () == 1) { // vive = 0; oculus = 1;
			Debug.Log ("Oculus Mode");
			oculusSetup.Invoke ();
		} else {
			Debug.Log ("Vive Mode");
			viveDestroy.Invoke ();
		}
		Destroy (this);
	}
}
