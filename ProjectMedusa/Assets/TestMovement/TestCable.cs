using UnityEngine;
using System.Collections;

public class TestCable : MonoBehaviour {

	Transform thisTF;

	Vector3 initPostion;

	Vector3 target;
	// Use this for initialization
	void Start () {
		thisTF = GetComponent<Transform> ();
		initPostion = thisTF.localPosition;

		target = Vector3.down * 2;

		col = GetComponent<CapsuleCollider> ();
	}

	float speed;

	CapsuleCollider col;

	public Transform model;

	void Update()
	{
		if (hand) 
			speed = Mathf.Lerp (speed, 0.04f, 0.01f);
		else
			speed = Mathf.Lerp (speed, -0.04f, 0.01f);
		hand = false;

		if (thisTF.localPosition.y < target.y && speed > 0)
			thisTF.position += Vector3.up * speed;
		
		if (thisTF.localPosition.y > initPostion.y && speed < 0)
			thisTF.position += Vector3.up * speed;
	


		col.center = Vector3.up * (Vector3.Distance (thisTF.position, thisTF.parent.position) / 2);
		col.height = Vector3.Distance(thisTF.position, thisTF.parent.position);

		model.localPosition = Vector3.down * (Vector3.Distance (thisTF.position, thisTF.parent.position) / 2);
		model.localScale = Vector3.right * 0.07f + Vector3.forward * 0.07f + 
			(Vector3.up *Vector3.Distance(thisTF.position, thisTF.parent.position) / 2);

		if (thisTF.GetChild (0)) {
			if (thisTF.GetChild (0).localPosition.y > Vector3.Distance (thisTF.position, thisTF.parent.position)) {
				thisTF.GetChild (0).parent = thisTF.parent;
			}
		}
	}

	public bool hand;

	void OnTriggerStay(Collider col)
	{
		if(col.tag == "Hand")
		{
			hand = true;
		}
	}

}
