using UnityEngine;
using System.Collections;

public class Fall : MonoBehaviour {

	Transform head;
	Transform thisTF;
	Rigidbody thisRB;

	AudioSource sound;

	[SerializeField] ParticleSystem respawnParticles;

	void Start () {
		head = GetComponent<Transform> ().FindChild ("Camera (eye)");
		thisTF = GetComponent<Transform> ();
		thisRB = GetComponent<Rigidbody> ();
		sound = GetComponent<AudioSource> ();
		SetSpawn (thisTF.position+Vector3.up*0.25f);
	}

	Vector3 spawn  = Vector3.zero;

	void Update () {
		if (thisTF.position.y < -45 || thisTF.position.y > 175 || thisTF.position.x > 55 || thisTF.position.x < -55 || thisTF.position.z > 55 || thisTF.position.z < -55) {
			Respawn ();
		}
	}

	void Respawn()
	{
		thisTF.position = spawn - (head.position - thisTF.position);
		thisRB.velocity = Vector3.zero;
		respawnParticles.Play ();
		GetComponent<AudioSource> ().Play ();
	}

	void SetSpawn (Vector3 vect)
	{
		spawn = vect;
	}

	void RespawnOnCollision()
	{
		deathFall = true;
	}
	bool deathFall;

	void OnCollisionEnter()
	{
		if (deathFall) {
			Respawn ();
		}
	}
}
