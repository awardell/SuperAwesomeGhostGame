using UnityEngine;
using System.Collections;

public class GlowScript : MonoBehaviour {

	// Use this for initialization
	void Awake () {
//		Debug.Log(this.transform.parent.gameObject.ToString());
		this.transform.parent.gameObject.GetComponent<CandleScript>().setGlow(gameObject);
	}

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
