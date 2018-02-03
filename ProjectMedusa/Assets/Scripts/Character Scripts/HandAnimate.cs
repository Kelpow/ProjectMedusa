using UnityEngine;
using System.Collections;

public class HandAnimate : MonoBehaviour {
	const int OPEN = 0;
	const int GRIP = 1;
	const int THUMB = 2;
	const int FINGER = 3;

	MeshFilter mesh;
	static Mesh openMesh;
	static Mesh gripMesh;
	static Mesh thumbMesh;
	static Mesh fingerMesh;

	[SerializeField] GameObject pointerHitbox;

	void Start () {
		mesh = GetComponent<MeshFilter> ();

		openMesh = (Mesh)Resources.Load("HandOpen",typeof(Mesh));
		gripMesh = (Mesh)Resources.Load("HandGrip",typeof(Mesh));
		thumbMesh = (Mesh)Resources.Load("HandThumb",typeof(Mesh));
		fingerMesh = (Mesh)Resources.Load("HandFinger",typeof(Mesh));

		mesh.mesh = openMesh;

		grab = GetComponent<Transform> ().parent.GetComponent<GrabBehavior> ();

		SetOpen();
	}

	public int currentMesh = 1234;

	GrabBehavior grab;

	void Update ()
	{
		if (currentMesh != grab.handMode) {
			switch (grab.handMode) {
			case OPEN:
				SetOpen ();
				break;
			case GRIP:
				SetGrab ();
				break;
			case THUMB:
				SetThumb ();
				break;
			case FINGER:
				SetFinger ();
				break;
			}
			currentMesh = grab.handMode;
		}
	}

	void SetGrab()
	{
		mesh.mesh = gripMesh;
		pointerHitbox.SetActive (false);
	}

	void SetOpen()
	{
		mesh.mesh = openMesh;
		pointerHitbox.SetActive (false);
	}

	void SetThumb()
	{
		mesh.mesh = thumbMesh;
		pointerHitbox.SetActive (false);
	}

	void SetFinger()
	{
		mesh.mesh = fingerMesh;
		pointerHitbox.SetActive (true);
	}

}
