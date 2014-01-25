using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	float speed = 5f;
	public enum Direction { Up, Right, Down, Left };
	Direction direction = 0;

	// Use this for initialization
	void Start () {
	
	}

	public void SetDirection(Direction newDirection) {
		direction = newDirection;
	}

	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey("up")) {
			direction = Direction.Up;
		} else if (Input.GetKey("down")) {
			direction = Direction.Down;
		} else if (Input.GetKey("left")) {
			direction = Direction.Left;
		} else if (Input.GetKey("right")) {
			direction = Direction.Right;
		}

		switch (direction) {
			case Direction.Up:
				this.rigidbody.velocity = new Vector3(0f, speed, 0f);
				break;
			case Direction.Down:
				this.rigidbody.velocity = new Vector3(0f,-speed, 0f);
				break;
			case Direction.Right:
				this.rigidbody.velocity = new Vector3(speed, 0f, 0f);
				break;
			case Direction.Left:
				this.rigidbody.velocity = new Vector3(-speed, 0f, 0f);
				break;
		}
	}
}
