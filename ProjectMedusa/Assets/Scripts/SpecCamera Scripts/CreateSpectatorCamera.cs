 using UnityEngine;
using System.Collections;

public class CreateSpectatorCamera : MonoBehaviour {

	GameObject cameraPrefab;

	void Start () {
		cameraPrefab = (GameObject)Resources.Load("Spectator Camera",typeof(GameObject));
	}
		
	public void CameraDestroy ()
	{
		GameObject cam = GameObject.Find("Spectator Camera");
		if (cam) {
			Destroy (cam);
		}
	}

	public void CameraCreate ()
	{
		GameObject cam = GameObject.Find("Spectator Camera");
		if (cam) {
			Destroy (cam);
		}
		GameObject newCam = Instantiate (cameraPrefab) as GameObject;
		newCam.name = "Spectator Camera";
		newCam.GetComponent<Transform> ().position = this.GetComponent<Transform> ().position;
		newCam.GetComponent<Transform> ().LookAt (GameObject.Find("Head").GetComponent<Transform> ());
	}
		
	public void CameraToggle ()
	{
		GameObject cam = GameObject.Find("Spectator Camera");
		if (cam) {
			Destroy (cam);
		} else {
			GameObject newCam = Instantiate (cameraPrefab) as GameObject;
			newCam.name = "Spectator Camera";
			newCam.GetComponent<Transform> ().position = this.GetComponent<Transform> ().position;
			newCam.GetComponent<Transform> ().LookAt (GameObject.Find("Head").GetComponent<Transform> ());
		}
	}
}
