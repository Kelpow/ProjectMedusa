using UnityEngine;
using System.Collections;
using EventHorizon;

public class EventDirector : MonoBehaviour {

	public Act[] acts;

	void DirectionsUpdate(int currentAct)
	{
		if (acts [currentAct].stage > acts [currentAct].events.Length - 1)
		{
			return; // if there are no more events exit the loop.
		}
		else
		{
			StartCoroutine(Delay (currentAct, acts [currentAct].Call ())); //call the Act and wait for delay;
		}
		acts [currentAct].stage++;//finish current Stage;
	}


	void BeginAct (int actIndex)
	{
		acts [actIndex].stage = 0;
		DirectionsUpdate (actIndex);
	}

	void BeginAct (string name)
	{
		for (int act = 0; act < acts.Length; act++) {
			if(acts[act].name == name)
			{
				BeginAct (act);
				return;
			}
		}
	}

	IEnumerator Delay(int currentAct, float delay)
	{
		yield return new WaitForSeconds (delay);
		DirectionsUpdate (currentAct);
	}

	//testing stuff
	bool isTesting;
	void Update()
	{
		//testing

			
	}

}
