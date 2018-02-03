using UnityEngine;
using System.Collections;

public class PickHolderBehavior : MonoBehaviour {

	const int CLEARED = -1;
	const int RED = 0;
	const int BLUE = 1;
	const int YELLOW = 2;
	const int PINK = 3;
	const int GREEN = 4;
	const int PURPLE = 5;
	const int ORANGE = 6;
	const int TEEL = 7;

	const int NONE = -1;
	const int FREE = 0;
	const int HELD = 1;
	const int USED = 2;

	public int[] pickFreeList;
	public int[] pickHeldList;
	public int[] pickUsedList;

	public GameObject[] picks;
	GameObject[] currentPicks;
	public GameObject pickRedPrefab;
	public GameObject pickBluePrefab;
	public GameObject pickYellowPrefab;

	GameObject currentRedPick;
	GameObject currentBluePick;
	GameObject currentYellowPick;

	void Start ()
	{
		pickFreeList = new int[8] {RED, BLUE, YELLOW, CLEARED, CLEARED, CLEARED, CLEARED, CLEARED};
		pickHeldList = new int[8] {CLEARED, CLEARED, CLEARED, CLEARED, CLEARED, CLEARED, CLEARED, CLEARED};
		pickUsedList = new int[8] {CLEARED, CLEARED, CLEARED, CLEARED, CLEARED, CLEARED, CLEARED, CLEARED};

		currentPicks = new GameObject[picks.Length];
		/*
		for (int q = 3; q < 8; q++) {
			//MoveLists (q, NONE, FREE);
		}
		*/
	}

	public GameObject SpawnPick (GrabBehavior grabScript)
	{
		GameObject pickPrefab;
		int chosenPick;

		bool isFree = true;

		for (int q = 0; q < pickFreeList.Length; q++) {
			if (pickFreeList [q] > CLEARED) {
				chosenPick = pickFreeList [q]; 
				Debug.Log ("Pick " + chosenPick + " from Free");
				goto chosen;
			}
		}
		isFree = false; //if none found on free list check on used list
		for (int q = 0; q < pickUsedList.Length; q++) {
			if (pickUsedList [q] > CLEARED) {  
				chosenPick = pickUsedList [q];
				Debug.Log ("Pick " + chosenPick + " from Used");
				goto chosen;
			}
		}
		chosenPick = YELLOW; //incase all else fails
		Debug.Log ("FUCK");
chosen:

		pickPrefab = picks[chosenPick];
		if (currentPicks[chosenPick]) {
			currentPicks[chosenPick].GetComponent<PickBehavior> ().Reclaim ();
		} 
		if (!isFree)
			UsedtoHeld (chosenPick);
		else 
			FreeToHeld (chosenPick); 

		//

		GameObject newPick = Instantiate (pickPrefab, grabScript.GetComponent<Transform> ().position, new Quaternion (), grabScript.GetComponent<Transform> ()) as GameObject;
		newPick.GetComponent<PickBehavior> ().pickNumber = chosenPick;

		currentPicks [chosenPick] = newPick;

		return newPick;

	}

	void Rearange (ref int[] list ,int movetoback)
	{
		int q = 0;
		while (q < list.Length)
		{
			if (list [q] == movetoback)
				break;
			q++;
		}

		if (q == list.Length)
			return;

		while (q < list.Length - 1) {
			list [q] = list [q + 1];
			q++;
		}

		list [list.Length - 1] = movetoback;
		return;
	}


	void Clear (ref int[] list, int toclear)
	{
		int q = 0;
		while (q < list.Length)
		{
			if (list [q] == toclear)
				break;
			q++;
		}
		if (q == list.Length)
			return;
		
		list [q] = CLEARED;
		return;
	}


	void MoveLists (int pick, int listFrom, int listTo)
	{
		MoveToBack (pick, listFrom); //push all others forward

		switch (listFrom) { // clear from the list
		case FREE:
			Clear (ref pickFreeList, pick);
			break;
		case HELD:
			Clear (ref pickHeldList, pick);
			break;
		case USED:
			Clear (ref pickUsedList, pick);
			break;
		default:
			Debug.Log("MoveLists: No list cleared");
			break;
		}
		switch (listTo) { // add to the To list
		case FREE:
			for (int q = pickFreeList.Length - 1; q >= 0; q--) {
				if (pickFreeList [q] == CLEARED) {
					pickFreeList [q] = pick;
					break;
				}
			}
			break;
		case HELD:
			for (int q = pickHeldList.Length - 1; q >= 0; q--) {
				if (pickHeldList [q] == CLEARED) {
					pickHeldList [q] = pick;
					break;
				}
			}
			break;
		case USED:
			for (int q = pickUsedList.Length - 1; q >= 0; q--) {
				if (pickUsedList [q] == CLEARED) {
					pickUsedList [q] = pick;
					break;
				}
			}
			break;
		}
		MoveToBack (pick, listTo);//move to back of new list
	}

	void MoveToBack(int pick, int list)
	{
		switch (list) {
		case FREE:
			Rearange (ref pickFreeList, pick);
			break;
		case HELD:
			Rearange (ref pickHeldList, pick);
			break;
		case USED:
			Rearange (ref pickUsedList, pick);
			break;
		}
	}

	public void BackOfUsed(int pick)
	{
		MoveToBack (pick, USED);
	}
	public void UsedtoHeld (int pick)
	{
		MoveLists (pick, USED, HELD);
	}
	public void HeldToUsed(int pick)
	{
		MoveLists (pick, HELD, USED);
	}
	public void HeldToFree(int pick)
	{
		MoveLists (pick, HELD, FREE);
	}
	public void FreeToHeld(int pick)
	{
		MoveLists (pick, FREE, HELD);
	}
}
