using UnityEngine;
using System.Collections;

public class PickBehavior : MonoBehaviour {

	public Transform thisTF;
	Rigidbody thisRB;

	public GrabBehavior grabScript;

	bool isHeld = true;

	public PickHolderBehavior holder;

	public BoxCollider backCheckCollider;

	public int pickNumber;

	void Start () {
		thisTF = GetComponent<Transform> ();
		thisRB = GetComponent<Rigidbody> ();
	}
	
	public void Drop (Vector3 velocity, Vector3 angularVelocity)
	{
		thisTF.parent = null;
		thisRB.isKinematic = false;

		thisRB.velocity = velocity;
		thisRB.angularVelocity = angularVelocity;

		isHeld = false;

		holder.HeldToFree (pickNumber);
	}

	[SerializeField]
	LayerMask backLayer;

	public void IceStab()
	{
		bool isOnBack = Physics.CheckBox (thisTF.position, backCheckCollider.size * 0.5f,thisTF.rotation, backLayer);
		if (!isHeld || isOnBack)
			return;

		thisTF.parent = null;
		this.gameObject.layer = 8; //8 is the current grab layer

		GetComponent<PlayRandomSound> ().Play ();

		holder.HeldToUsed(pickNumber); //change from current pick to back of list

		grabScript.PickStab (thisTF);
	}

	public void Reclaim ()
	{
		this.gameObject.BroadcastMessage ("Spawn");

		if (thisTF.FindChild ("GrabPoint")) {
			thisTF.FindChild ("GrabPoint").parent = null;
		}
		Destroy (this.gameObject);
	}

	bool hasGrabbed;

	void OnTriggerStay (Collider col)
	{
		if (col.tag == "Hand") {
			if (col.gameObject.GetComponent<ClickAndDrag> ().grabbing) {
				if (!hasGrabbed && thisRB.isKinematic) {
					holder.BackOfUsed (pickNumber); 
					hasGrabbed = true;
				}
			} else {
				hasGrabbed = false;
			}
		}
	}
}
