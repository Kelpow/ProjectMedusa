using UnityEngine;
using System.Collections;

public class NoClipping : MonoBehaviour {

	public GameObject rightHand;
	public GameObject leftHand;

	public LayerMask solidMask;

	void Update()
	{
		if(Physics.CheckSphere(GetComponent<Transform>().position, 0.1f, solidMask))
		{
			rightHand.GetComponent<ClickAndDrag> ().LetGo ();
			leftHand.GetComponent<ClickAndDrag> ().LetGo ();
		}
	}
}
