using UnityEngine;
using System.Collections;

public class EnemyMirror : MonoBehaviour {

	public Transform player;
	public bool mirrorX = false;
	public bool mirrorY = false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		this.rigidbody2D.velocity = new Vector3(
			player.rigidbody2D.velocity.x * (mirrorX ? -1 : 1),
			player.rigidbody2D.velocity.y * (mirrorY ? -1 : 1)
			);
	}
}
