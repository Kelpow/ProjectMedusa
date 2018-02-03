using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotCheat : MonoBehaviour {

	public void Screenshot(int upscale) {
		string timestamp = System.DateTime.Today.ToString();
		//timestamp = timestamp.Replace (' ', '_');
		timestamp = timestamp.Substring(0, timestamp.IndexOf(' '));
		timestamp = timestamp.Replace ('/', '_');
		timestamp = timestamp.Replace (':', '_');
		Debug.Log (timestamp);
		Application.CaptureScreenshot ("Screenshot" + timestamp + "_" + Mathf.Round(Time.realtimeSinceStartup*100) + ".png", upscale);
	}

	void Update () {
		if (Input.GetButtonDown ("Screenshot"))
			Screenshot (2);

		if (Input.GetButton ("ScreenshotLeft")) {
			if (Input.GetButtonDown ("ScreenshotRight"))
				Screenshot (2);
		}
	}
}
