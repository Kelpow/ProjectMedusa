//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Helper to update poses when using native OpenVR integration.
//
//=============================================================================

using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(Camera))]
public class SteamVR_UpdatePoses : MonoBehaviour
{
	void Awake()
	{
		var camera = GetComponent<Camera>();
		camera.stereoTargetEye = StereoTargetEyeMask.None;
		//camera.clearFlags = CameraClearFlags.Nothing;
		camera.useOcclusionCulling = false;
		camera.cullingMask = 0;
		camera.depth = -9999;

		t = Time.realtimeSinceStartup;
	}

	bool hasDisabled;
	float t;
	void Update()
	{
		if (!hasDisabled) {
			Debug.LogWarning ("AARON REMEMBER YOU DID THIS IF SHIT BREAKS FIX IT", this);
			if (Time.realtimeSinceStartup > t + 1f) {
				GetComponent<Camera> ().stereoTargetEye = StereoTargetEyeMask.Both; hasDisabled = true;
			}
		}
	}

	void OnPreCull()
	{
		var compositor = OpenVR.Compositor;
		if (compositor != null)
		{
			var render = SteamVR_Render.instance;
			compositor.GetLastPoses(render.poses, render.gamePoses);
			SteamVR_Utils.Event.Send("new_poses", render.poses);
			SteamVR_Utils.Event.Send("new_poses_applied");
		}
	}
}

