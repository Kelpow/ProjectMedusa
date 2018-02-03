using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SpawnControl : MonoBehaviour {

	public GameObject[] spawns;
	Vector3 [] spawnPoints;

	GameObject player;
	void Start () {
		PlayerPrefs.Save();
		player = GameObject.Find ("[CameraRig]");
		spawnPoints = new Vector3[spawns.Length];

		for (int q = 0; q < spawns.Length; q++) {
			spawns [q].GetComponent<Checkpoint> ().spawnNumber = q;
			spawnPoints [q] = spawns [q].GetComponent<Transform> ().position;
		}
		if (PlayerPrefs.HasKey ("lastSpawn")) {
			ReportSpawn (PlayerPrefs.GetInt ("lastSpawn"));
			player.SendMessage ("Respawn");
		} else {
			ReportSpawn (0);
			player.SendMessage ("Respawn");
		}
		PlayerPrefs.Save();
	}

	void ReportSpawn(int num)
	{
		PlayerPrefs.SetInt ("lastSpawn", num);
		player.SendMessage ("SetSpawn", spawnPoints [num]);
		PlayerPrefs.Save();
		ClearAll ();
		spawns [num].SendMessage ("Effects");
	}

	void ReportSpawn(Vector3 point)
	{
		player.SendMessage ("SetSpawn", point);
		ClearAll ();
	}

	public void ClearAll()
	{
		for (int q = 0; q < spawns.Length; q++) {
			spawns [q].SendMessage ("Clear");
		}
	}

	void Update ()
	{
		if (Input.GetKey (KeyCode.J)) {
			Debug.Log (PlayerPrefs.GetInt ("lastSpawn"));
		}

		if (Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.E) && Input.GetKey(KeyCode.L)) {
			PlayerPrefs.DeleteAll ();
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}
}
