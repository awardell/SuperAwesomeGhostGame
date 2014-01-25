using UnityEngine;
using System.Collections;

public class EnemyMirror : MonoBehaviour {

	public Transform player;
	public bool mirrorX = false;
	public bool mirrorY = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.rigidbody.velocity = new Vector3(
			player.rigidbody.velocity.x * (mirrorX ? -1 : 1),
			player.rigidbody.velocity.y * (mirrorY ? -1 : 1),
			player.rigidbody.velocity.z
			);
	}
}
