using UnityEngine;
using System.Collections;

public class PlayerCollisionBehavior : MonoBehaviour {

	Transform thisTF;
	[SerializeField] Transform parentTF;
	SphereCollider parentCC;

	[SerializeField] ClickAndDrag righHand;
	[SerializeField] ClickAndDrag leftHand;

	float originalRadius;

	void Start () {
		thisTF = GetComponent<Transform> ();

		parentCC = parentTF.gameObject.GetComponent<SphereCollider> ();
		parentCC.center = Vector3.one;

		originalRadius = parentCC.radius;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 centerPos = parentTF.InverseTransformPoint(thisTF.position);

		parentCC.center = centerPos;

		if (righHand.grabbing || leftHand.grabbing) {
			parentCC.radius = 0.1f;
		} else {
			parentCC.radius = Mathf.Lerp (parentCC.radius, originalRadius, 0.2f);
		}
	}
}
