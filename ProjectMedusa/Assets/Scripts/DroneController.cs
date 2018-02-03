using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour {

	Rigidbody ThisRB;
	Transform ThisTF;
	Transform body;
	Transform cameraMount;

	[SerializeField] float speed;
	[SerializeField] float rotSpeed;


	void Start () {
		ThisRB = GetComponent<Rigidbody> ();
		ThisTF = GetComponent<Transform> ();
		cameraMount = ThisTF.GetChild (0);
		body = ThisTF.GetChild (1);
	}

	Vector3 up;
	Vector3 forward;

	float cameraRotation = 27;

	void Update () {
		ThisRB.AddForce (Vector3.up * speed * Input.GetAxisRaw("Jump"));
		ThisRB.AddTorque(Vector3.up * rotSpeed * Input.GetAxis("X axis"));

		ThisRB.AddForce(ThisTF.forward * speed * Input.GetAxisRaw("Vertical"));
		ThisRB.AddForce(ThisTF.right * speed * Input.GetAxisRaw("Horizontal")); 

		if (Input.GetButtonDown ("Speed Up")) {
			speed += speed / 2f;
		}
		if (Input.GetButtonDown ("Speed Down")) {
			speed -= speed / 3f ;
		}

		cameraRotation = Mathf.Clamp (cameraRotation + Input.GetAxis ("Y axis") * rotSpeed, -60, 60);
		cameraMount.localRotation = Quaternion.Euler (Vector3.right * cameraRotation);

		forward = Vector3.Lerp(forward, ThisTF.forward - (Vector3.up* Input.GetAxisRaw("Vertical") * 0.5f), 0.1f);
			up = Vector3.Lerp(up, Vector3.up + (ThisTF.right * Input.GetAxisRaw("Horizontal") * 0.5f), 0.1f);

		body.LookAt (ThisTF.position + forward, up);
	}
}
