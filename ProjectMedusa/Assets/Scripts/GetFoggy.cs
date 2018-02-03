using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFoggy : MonoBehaviour {

	[SerializeField] Transform thisTF;
	[SerializeField] HeadSpeed head;


	[SerializeField] float max, min, target;
	float difference;
	void Start () 
	{
		difference = max - min;
	}

	public bool isDynamic;

	public void SetDynamic (bool dynamic)
	{
		isDynamic = dynamic;
	}

	Quaternion rot;

	void Update () 
	{
		float aimingFor = (head.velocity / target < 1f)? head.velocity / target : 1f;
		if (!isDynamic)
			aimingFor = 1f;

		if (rot != head.GetComponent<Transform> ().rotation)
			aimingFor = 1f;
		rot = head.GetComponent<Transform> ().rotation;

		thisTF.localScale = Vector3.Lerp (thisTF.localScale, (Vector3.one * max) - (Vector3.one * aimingFor * difference), 0.1f);
	}
}
