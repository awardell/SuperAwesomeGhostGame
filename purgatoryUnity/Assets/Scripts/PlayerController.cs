using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 5f;
	public enum Direction { Up, Right, Down, Left, None };
	Direction direction;
	Direction badDirection = Direction.None;

	Vector3 prevPos;

	// Use this for initialization
	void Start () {
		direction = Direction.None;
	}

	public void SetDirection(Direction newDirection) {
		direction = newDirection;
		startPlayer ();
	}

	public Direction GetDirection() {
		return direction;
	}

	public void startPlayer() {
		// in case moving is reintegrated
	}

	public void stopPlayer() {
		direction = Direction.None;
	}
	public void stopPlayer(Direction _badDirection) {//Prevent players from clipping through walls
		direction = Direction.None;
		badDirection = _badDirection;
		//this.transform.position = prevPos;
	}

	// Update is called once per frame
	void Update () {
		prevPos = this.transform.position;

		if (Input.GetKey("up") && badDirection != Direction.Up) {
			SetDirection(Direction.Up);
		} else if (Input.GetKey("down") && badDirection != Direction.Down) {
			SetDirection(Direction.Down);
		} else if (Input.GetKey("left") && badDirection != Direction.Left) {
			SetDirection(Direction.Left);
		} else if (Input.GetKey("right") && badDirection != Direction.Right) {
			SetDirection(Direction.Right);
		}
		
		switch (direction) {
			case Direction.Up:
				this.rigidbody2D.velocity = new Vector3(0f, speed, 0f);
				if(badDirection == Direction.Down)
					badDirection = Direction.None;
				break;
			case Direction.Down:
				this.rigidbody2D.velocity = new Vector3(0f,-speed, 0f);
				if(badDirection == Direction.Up)
					badDirection = Direction.None;
				break;
			case Direction.Right:
				this.rigidbody2D.velocity = new Vector3(speed, 0f, 0f);
				if(badDirection == Direction.Left)
					badDirection = Direction.None;
				break;
			case Direction.Left:
				this.rigidbody2D.velocity = new Vector3(-speed, 0f, 0f);
				if(badDirection == Direction.Right)
					badDirection = Direction.None;
				break;
			case Direction.None:
				this.rigidbody2D.velocity = Vector3.zero;
				break;
		}
	}
}
