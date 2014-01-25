using UnityEngine;
using System.Collections;

public class TouchControls : MonoBehaviour {

	public Transform player;
	PlayerController playerControls;
	int swipeDist = 10;

	// Use this for initialization
	void Start () {
		playerControls = player.gameObject.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
		// Code by tmanallen 
		// http://forum.unity3d.com/threads/185590-Collision-detection-with-swipe-gesture
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			RaycastHit hit;
			Vector3 touchesDeltaPosition = Input.GetTouch (0).deltaPosition;
			Ray ray = Camera.main.ScreenPointToRay(touchesDeltaPosition);
			if (touchesDeltaPosition.x > swipeDist)
				playerControls.SetDirection(PlayerController.Direction.Right);
			if (touchesDeltaPosition.x <-swipeDist)
				playerControls.SetDirection(PlayerController.Direction.Left);
			if (touchesDeltaPosition.y > swipeDist)
				playerControls.SetDirection(PlayerController.Direction.Up);
			if (touchesDeltaPosition.y <-swipeDist)
				playerControls.SetDirection(PlayerController.Direction.Down);
		}
	}

}
