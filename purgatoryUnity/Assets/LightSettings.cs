using UnityEngine;
using System.Collections;

// Make the script also execute in edit mode.
[ExecuteInEditMode()]  
public class LightSettings : MonoBehaviour {
	public Color ambientColor;

	// Use this for initialization
	void Start () {
		RenderSettings.ambientLight = ambientColor;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
