using UnityEngine;
using System.Collections;

public class EnemyMirror : EnemyMove {

	public bool mirrorX, mirrorY;
	public Vector3 prevPos;

	// Use this for initialization
	void Start () {
		mirrorX = mirrorY = false;
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
