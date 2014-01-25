using UnityEngine;
using System.Collections;

public class EnemyMirror : MonoBehaviour {

	public Transform player;
	public bool mirrorX = false;
	public bool mirrorY = false;
	public Vector3 prevPos;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	public void moveFromCollision() {
		this.transform.position = prevPos;
	}

	// Update is called once per frame\
	protected void Update () {
		prevPos = this.transform.position;

		this.rigidbody2D.velocity = new Vector3(
			player.rigidbody2D.velocity.x * (mirrorX ? -1 : 1),
			player.rigidbody2D.velocity.y * (mirrorY ? -1 : 1)
			);
	}
}
