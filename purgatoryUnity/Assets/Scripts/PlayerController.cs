﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	float speed = 5f;
	public enum Direction { Up, Right, Down, Left, None };
	Direction direction = 0;
	Direction badDirection = Direction.None;
	bool moving = false;

	// Use this for initialization
	void Start () {
		moving = false;
	}

	public void SetDirection(Direction newDirection) {
		direction = newDirection;
	}

	public Direction GetDirection() {
		return direction;
	}

	public void stopPlayer() {
		moving = false;
	}
	public void stopPlayer(Direction _badDirection) {//Prevent players from clipping through walls
		moving = false;
		badDirection = _badDirection;
	}

	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey("up") && badDirection != Direction.Up) {
			direction = Direction.Up;
			moving = true;
		} else if (Input.GetKey("down") && badDirection != Direction.Down) {
			direction = Direction.Down;
			moving = true;

		} else if (Input.GetKey("left") && badDirection != Direction.Left) {
			direction = Direction.Left;
			moving = true;
		} else if (Input.GetKey("right") && badDirection != Direction.Right) {
			direction = Direction.Right;
			moving = true;
		}
		else {
//			moving = false;
		}

		if(moving) {
			switch (direction) {
				case Direction.Up:
					this.rigidbody.velocity = new Vector3(0f, speed, 0f);
					if(badDirection == Direction.Down)
						badDirection = Direction.None;
					break;
				case Direction.Down:
					this.rigidbody.velocity = new Vector3(0f,-speed, 0f);
					if(badDirection == Direction.Up)
						badDirection = Direction.None;
					break;
				case Direction.Right:
					this.rigidbody.velocity = new Vector3(speed, 0f, 0f);
					if(badDirection == Direction.Left)
						badDirection = Direction.None;
					break;
				case Direction.Left:
					this.rigidbody.velocity = new Vector3(-speed, 0f, 0f);
					if(badDirection == Direction.Right)
						badDirection = Direction.None;
					break;
			}
		}
		else {
			this.rigidbody.velocity = Vector3.zero;
		}
	}
}
