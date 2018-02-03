using UnityEngine;
using System.Collections;

public class RedXActing : MonoBehaviour {


	Renderer thisRend;
	Renderer childRend;

	[SerializeField]
	string eventDirection;

	void Start () {
		thisRend = GetComponent<Renderer> ();
		childRend = GetComponent<Transform> ().GetChild (0).GetComponent<Renderer> ();
	}

	/*
	void ActorEvent(string direction)
	{
		if (direction == eventDirection) 
		{
			StartCoroutine (BlinkToOn());
		}
		if (direction == "THIS is you") 
		{
			Blink (false);
		}
	}
	//*/
	IEnumerator BlinkToOn()
	{
		Blink (true);
		yield return new WaitForSeconds (0.3f);
		Blink (false);
		yield return new WaitForSeconds (0.3f);
		Blink (true);
		yield return new WaitForSeconds (0.3f);
		Blink (false);
		yield return new WaitForSeconds (0.3f);
		Blink (true);
	}
	void Blink(bool b)
	{
		thisRend.enabled = b;
		childRend.enabled = b;
	}

	public void StartBlink()
	{
		StartCoroutine (BlinkToOn());
	}
	public void Hide ()
	{
		Blink (false);
	}
}
