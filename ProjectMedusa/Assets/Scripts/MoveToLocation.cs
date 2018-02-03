using UnityEngine;
using System.Collections;

public class MoveToLocation : MonoBehaviour {
	
	[SerializeField] float speed;
	Vector3 targetLocation;
	Vector3 targetRotation;


	public int currentTarget;
	[SerializeField] Vector3[] targetsT;
	[SerializeField] Vector3[] targetsR;

	Transform thisTF;


	// Use this for initialization
	void Start () {
		thisTF = GetComponent<Transform> ();
		targetLocation = targetsT [0];
		targetRotation = targetsR [0];
		thisTF.position = targetLocation;
		thisTF.rotation = Quaternion.LookRotation (targetRotation);
	}
	
	// Update is called once per frame
	void Update () {
		thisTF.position = Vector3.Lerp (thisTF.position, targetLocation, speed);
		thisTF.rotation = Quaternion.Lerp (thisTF.rotation, Quaternion.LookRotation (targetRotation), speed);
	}

	[ContextMenu("FakeActor")]
	void ActorEvent()
	{
		currentTarget++;
		if (currentTarget < targetsT.Length) {
			targetLocation = targetsT [currentTarget];
			targetRotation = targetsR [currentTarget];
		}
	}
	[ContextMenu("Add position to Targets")]
	void AddPositionToTargets ()
	{
		Vector3[] tempT = targetsT;
		Vector3[] tempR = targetsR;
		targetsT = new Vector3[targetsT.Length + 1];
		targetsR = new Vector3[targetsR.Length + 1];
		for (int q = 0; q < tempT.Length; q++) {
			targetsT [q] = tempT [q];
			targetsR [q] = tempR [q];
		}
		targetsT [targetsT.Length - 1] = GetComponent<Transform> ().position;
		targetsR [targetsR.Length - 1] = GetComponent<Transform> ().forward;
	}
}
