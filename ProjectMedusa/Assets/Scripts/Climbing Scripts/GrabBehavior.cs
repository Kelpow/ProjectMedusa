using UnityEngine;
using System.Collections;


public class GrabBehavior : MonoBehaviour {
	const int OPEN = 0;
	const int GRIP = 1;
	const int THUMB = 2;
	const int FINGER = 3;

	public int handMode;

	[Header("Referenced Objects")]
	public GameObject otherController;
	public GameObject grabPointObject;
	public PickHolderBehavior pickHolder;
	[Header("Grabbing Variables")]
	public LayerMask grabMask;

	Transform thisTF;

	ClickAndDrag dragScript;
	ClickAndDrag otherDragScript;

	GameObject handModel;


	SteamVR_TrackedObject trackedObj;
	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

	void Start () 
	{
		thisTF = GetComponent<Transform> ();

		dragScript = GetComponent<ClickAndDrag> ();
		otherDragScript = otherController.GetComponent<ClickAndDrag> ();

		handModel = thisTF.GetChild (0).gameObject;

		pickPosition = thisTF.FindChild ("PickPosition");
	}

	bool holdPoint = false;

	public int holdNum = 0;

	[HideInInspector] public Transform lastGrabObject;

	//Camera Variables
	bool touchingCamera;
	bool holdingCamera;

	//Pick Variables


	Transform pickPosition;
	GameObject heldPick;
	bool touchingPick;
	public bool holdingPick;


	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.layer == 8) {
			holdNum += 1;
			lastGrabObject = col.gameObject.GetComponent<Transform> ();
			return;
		}

		if (col.tag == "Cam") {
			touchingCamera = true;
		}
		if (col.tag == "Pick") {
			touchingPick = true;
		}
	}

	public float lastGrabTime; //last time the trigger was pulled

	void Update () {
		var device = SteamVR_Controller.Input((int)trackedObj.index);

		holdPoint = (holdNum > 0); 

		if (device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) 
		{
			lastGrabTime = Time.time;

			if(touchingCamera){ //don't grab if touching the camera;
				GameObject.Find ("Spectator Camera").SendMessage ("HandGrab", thisTF);
				holdingCamera = true;
			}	
			else if (touchingPick)
			{
				GameObject newPick = pickHolder.SpawnPick (this);
				heldPick = newPick;
				newPick.GetComponent<Transform> ().localPosition = pickPosition.localPosition;
				newPick.GetComponent<Transform> ().localRotation = pickPosition.localRotation;
				newPick.GetComponent<PickBehavior> ().grabScript = this;
				newPick.GetComponent<PickBehavior> ().holder = pickHolder;
				holdingPick = true;

			}
			else if (holdPoint) 
			{

				otherDragScript.LetGo ();

				grabPointObject.GetComponent<Transform> ().position = thisTF.position;
				grabPointObject.GetComponent<Transform> ().parent = lastGrabObject.GetComponent<Transform> ();

				dragScript.Grab ();
				
				this.GetComponent<AudioSource> ().Play (); //play grab noise
			}
		}



		if (device.GetPressUp (SteamVR_Controller.ButtonMask.Trigger)) {

			dragScript.LetGo ();


			handModel.SendMessage ("SetOpen");

			if (holdingCamera) {
				GameObject.Find ("Spectator Camera").SendMessage ("HandRelease", thisTF);
			}
			if (holdingPick) {
				heldPick.GetComponent<PickBehavior> ().Drop (thisTF.parent.TransformVector(device.velocity) + thisTF.parent.GetComponent<Rigidbody>().velocity, thisTF.parent.TransformVector(device.angularVelocity));
			}
			holdingCamera = false;
			holdingPick = false;
			 //animate release
		}


		//Cosmetic Animations
		/*
		if (!device.GetPress (SteamVR_Controller.ButtonMask.Trigger) && device.GetPressDown (SteamVR_Controller.ButtonMask.Touchpad)) {
			handModel.SendMessage ("SetThumb");
		}
		if (!device.GetPress (SteamVR_Controller.ButtonMask.Trigger) && device.GetPressUp (SteamVR_Controller.ButtonMask.Touchpad)) {
			handModel.SendMessage ("SetOpen");
		}
		if (!device.GetPress (SteamVR_Controller.ButtonMask.Trigger) && device.GetPressDown (SteamVR_Controller.ButtonMask.Grip)) {
			handModel.SendMessage ("SetFinger");
		}  
		if (!device.GetPress (SteamVR_Controller.ButtonMask.Trigger) && device.GetPressUp (SteamVR_Controller.ButtonMask.Grip)) {
			handModel.SendMessage ("SetOpen");
		}
		//*/

		if (device.GetPress (SteamVR_Controller.ButtonMask.Trigger)) {
			handMode = GRIP;
		} else if (device.GetPress (SteamVR_Controller.ButtonMask.Grip)) {
			handMode = FINGER;
		} else if (device.GetPress (SteamVR_Controller.ButtonMask.Touchpad)) {
			handMode = THUMB;
		} else {
			handMode = OPEN;
		}
	}

	public void PickStab()
	{
		holdingPick = false;
		dragScript.LetGo ();
		otherDragScript.LetGo();
		dragScript.Grab ();
		grabPointObject.GetComponent<Transform> ().parent = null;
	}
	public void PickStab(Transform tf)
	{
		holdingPick = false;
		dragScript.LetGo ();
		otherDragScript.LetGo();
		dragScript.Grab ();
		grabPointObject.GetComponent<Transform> ().parent = tf;
	}

	void LateUpdate()
	{
		holdNum = 0;
		touchingCamera = false;
		touchingPick = false;
	}
}
