using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockLOD : MonoBehaviour {

	public LODGroup group;

	public float percent;

	void Start()
	{
		// Programmatically create a LOD group and add LOD levels. 
		// Create a GUI that allows for forcing a specific LOD level.
		group = gameObject.AddComponent<LODGroup>() as LODGroup;

		// Add 4 LOD levels
		LOD[] lods = new LOD[1];

		Renderer[] renderers = new Renderer[0];

		renderers = new Renderer[1];
		renderers [0] = GetComponent<MeshRenderer> ();
	
		lods[0] = new LOD(percent, renderers);

		group.SetLODs(lods);
		group.RecalculateBounds();
	}

}
