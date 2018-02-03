using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickGrab : MonoBehaviour {

	[SerializeField] GameObject parent;
	[SerializeField] GameObject other;
	[SerializeField] string message;

	[SerializeField] ParticleSystem particle;
	[SerializeField] ParticleSystem otherparticle;


	void OnTriggerStay (Collider col)
	{
		if (col.tag == "Hand") {
			if (col.gameObject.GetComponent<GrabBehavior> ().lastGrabTime > Time.time - 0.3f) 
			{
				particle.Play ();
				otherparticle.Play ();
				parent.SendMessage (message);
				Destroy(other);
				Destroy(this.gameObject);
			}
		}
	}
}
