using UnityEngine;
using System.Collections;

public class PlayerKiller : MonoBehaviour {

	public bool isPit = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		//Debug.Log ("Collided with " + collider.gameObject.tag);
		if (collider.gameObject.tag == "Player") {
			Application.LoadLevel("Lose");
		} else if (isPit && collider.gameObject.tag == "Enemy") {
			Application.LoadLevel(Application.loadedLevel+1);
		}
	}
}
