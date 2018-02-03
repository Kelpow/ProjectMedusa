using UnityEngine;
using System.Collections;

public class PickHolderBehaviorOld : MonoBehaviour {

	const int RED = 0;
	const int BLUE = 1;
	const int YELLOW = 2;


	public int[] pickNumberList;

	public GameObject pickRedPrefab;
	public GameObject pickBluePrefab;
	public GameObject pickYellowPrefab;

	GameObject currentRedPick;
	GameObject currentBluePick;
	GameObject currentYellowPick;

	void Start ()
	{
		pickNumberList = new int[3] {RED, BLUE, YELLOW};
		Rearange (BLUE);
	}

	public GameObject SpawnPick (GrabBehavior grabScript)
	{
		GameObject pickPrefab;

		switch (pickNumberList[0])
		{
		case RED:
			pickPrefab = pickRedPrefab;
			if (currentRedPick)
				currentRedPick.GetComponent<PickBehavior> ().Reclaim ();
			break;
		case BLUE:
			pickPrefab = pickBluePrefab;
			if (currentBluePick)
				currentBluePick.GetComponent<PickBehavior> ().Reclaim ();
			break;
		case YELLOW:
			pickPrefab = pickYellowPrefab;
			if (currentYellowPick)
				currentYellowPick.GetComponent<PickBehavior> ().Reclaim ();
			break;
		default:
			pickPrefab = pickYellowPrefab; // I swear if this code ever runs just fuking shoot me
			break;
		}

		GameObject newPick = Instantiate (pickPrefab, grabScript.GetComponent<Transform> ().position, new Quaternion (), grabScript.GetComponent<Transform> ()) as GameObject;
		newPick.GetComponent<PickBehavior> ().pickNumber = pickNumberList [0];

		switch (pickNumberList[0])
		{
		case RED:
			currentRedPick = newPick;
			break;
		case BLUE:
			currentBluePick = newPick;
			break;
		case YELLOW:
			currentYellowPick = newPick;
			break;
		}

		return newPick;

	}

	public int[] Rearange (int movetoback)
	{
		int q = 0;
		while (q < pickNumberList.Length)
		{
			if (pickNumberList [q] == movetoback)
				break;
			q++;
		}

		if (q == pickNumberList.Length)
			return pickNumberList;

		while (q < pickNumberList.Length - 1) {
			pickNumberList [q] = pickNumberList [q + 1];
			q++;
		}

		pickNumberList [pickNumberList.Length - 1] = movetoback;
		return pickNumberList;
	}
}
