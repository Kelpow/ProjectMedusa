using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagChangeScript : MonoBehaviour {

	[SerializeField] Material offMat;
	[SerializeField] Material onMat;

	public void Effects()
	{
		GetComponent<SkinnedMeshRenderer> ().material = onMat;
	}
	void Clear()
	{
		GetComponent<SkinnedMeshRenderer> ().material = offMat;
	}
}
