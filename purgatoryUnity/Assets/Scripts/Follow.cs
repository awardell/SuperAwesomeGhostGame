using UnityEngine;
using System.Collections;

// Make the script also execute in edit mode.
[ExecuteInEditMode()]  
public class Follow : MonoBehaviour {

	public GameObject objectToTrack;

	// Use this for initialization
	void Start () {
	}
	
	// Just a simple script that looks at the target transform.
	void Update () {
		Vector3 lookVec = objectToTrack.transform.position - transform.position;
		float shaftHeight = lookVec.magnitude;
		float shaftRadius = Mathf.Tan( Mathf.Deg2Rad*light.spotAngle ) * shaftHeight;

		Debug.Log ("DistToTarget = " + shaftHeight);
		Debug.Log ("ShaftRadius = " + shaftRadius);

		transform.LookAt(objectToTrack.transform);

		Transform lightShaftTransform = transform.Find ("LightShaft");
		lightShaftTransform.localScale = new Vector3 (shaftRadius, shaftHeight, shaftRadius);
		lightShaftTransform.localPosition = new Vector3 (0, 0, shaftHeight/2);
	}
}