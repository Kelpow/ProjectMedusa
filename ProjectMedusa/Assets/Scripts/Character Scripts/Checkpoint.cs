using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	public int spawnNumber;

	Vector3 pos;
	GameObject spawnManager;

	[SerializeField] GameObject Flag;
	Transform FlagTF;
	BoxCollider FlagBC;

	[SerializeField] LayerMask handMask;
	public bool isSpawn;

	void Start () {
		pos = GetComponent<Transform> ().position;
		spawnManager = GameObject.Find ("Spawn Manager");

		FlagTF = Flag.GetComponent<Transform> ();
		FlagBC = Flag.GetComponent<BoxCollider> ();
	}

	void OnTriggerEnter (Collider col) { //used for spawn Override to not save. Currently used for credits.
		if (col.tag == "Player") {
			spawnManager.SendMessage ("ReportSpawn", GetComponent<Transform>().position); //save as last checkpoint 
		}
	}

	void Update()
	{
		if (!Flag)
			return;

		if (!isSpawn && Physics.CheckBox (FlagTF.position, Vector3.Scale(FlagBC.size, FlagTF.localScale), FlagTF.rotation, handMask)) {
			ActivateSpawn ();
		}
	}

	void Effects ()
	{
		Flag.BroadcastMessage ("Effects");
		isSpawn = true;
	}

	void Clear()
	{
		isSpawn = false;
		Flag.BroadcastMessage ("Clear");
	}

	public void ActivateSpawn()
	{
		spawnManager.SendMessage ("ReportSpawn", spawnNumber); //save as last checkpoint
	}
}
