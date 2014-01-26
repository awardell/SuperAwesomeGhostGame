﻿using UnityEngine;
using System.Collections;

public class EnemyMirror : EnemyMove {

	public bool mirrorX = false, mirrorY = false;

	// Use this for initialization
	void Start () {

	}


	// Update is called once per frame\
	protected void Update () {
		UpdatePrev ();

		this.rigidbody2D.velocity = new Vector3(
			player.rigidbody2D.velocity.x * (mirrorX ? -1 : 1),
			player.rigidbody2D.velocity.y * (mirrorY ? -1 : 1)
		);
	}
}
