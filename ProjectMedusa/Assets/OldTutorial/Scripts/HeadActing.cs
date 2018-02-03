using UnityEngine;
using System.Collections;

public class HeadActing : MonoBehaviour {

	Animator anim;



	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	/*
	void ActorEvent(string direction)
	{
		switch (direction) {
		case "this is you":
			anim.SetTrigger ("PopUp");
			break;
		case "THIS is you":
			anim.SetTrigger ("HeadGrow");
			break;
		case "give it a go":
			anim.SetTrigger ("HeadShrink");
			break;
		case "start W&T":
			Destroy (this.gameObject);
			break;
		}
	}
	//*/

	public void ThisIsYou()
	{
		anim.SetTrigger ("PopUp");
	}
	public void THISisYou()
	{
		anim.SetTrigger ("HeadGrow");
	}
	public void GiveItAGo()
	{
		anim.SetTrigger ("HeadShrink");
	}
	public void StartWT()
	{
		Destroy (this.gameObject);
	}
}
