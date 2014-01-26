using UnityEngine;
using System.Collections;

public class TouchControls : MonoBehaviour {

	public Transform player;
	PlayerController playerControls;
	int swipeDist = 10;
	bool alreadyDragging = false;

	// Use this for initialization
	void Start () {
		playerControls = player.gameObject.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
		catchMouse ();

		//catchDrags();

		//catchSwipes();

	}

	void catchMouse() {
		if (Input.GetMouseButton(0)) {
			Vector3 dragPosition = Input.mousePosition;
			Ray ray = Camera.main.ScreenPointToRay(dragPosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 100)) {
				Vector3 cameraTransform = Camera.main.transform.InverseTransformPoint(0, 0, 0);
				Vector3 cameraTransformedPos = new Vector3(dragPosition.x, dragPosition.y, cameraTransform.z - 0.5f);
				Vector3 newPos = Camera.main.ScreenToWorldPoint(cameraTransformedPos);
				newPos.z = player.transform.position.z;
				bool firstTouch = !alreadyDragging &&
					(Mathf.Abs ((newPos - player.transform.position).magnitude) < 0.5);
				if (firstTouch || alreadyDragging) {
					Vector3 delta = (newPos - player.transform.position);
					delta *= 100*delta.magnitude;
					player.rigidbody2D.velocity = new Vector2(delta.x,delta.y);
					//player.rigidbody2D.AddForce((newPos - player.transform.position)*1000f);
					//player.transform.position = newPos;
					alreadyDragging = true;
				}
			}
		} 

		if (!Input.GetMouseButton(0) && alreadyDragging) {
			alreadyDragging = false;
		}
	}

	void catchDrags() {

		// Code by Little Angel
		// http://forum.unity3d.com/threads/74952-Moving-an-object-by-touch-gt-drag
		foreach (Touch touch in Input.touches) {
    		Ray ray = Camera.main.ScreenPointToRay(touch.position);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 100)) {
				if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved) {
					Vector3 cameraTransform = Camera.main.transform.InverseTransformPoint(0, 0, 0);
					Vector3 touchPos = new Vector3(touch.position.x, touch.position.y, cameraTransform.z - 0.5f);
					Vector3 newPos = Camera.main.ScreenToWorldPoint(touchPos);
					newPos.z = player.transform.position.z;
					bool firstTouch = touch.phase == TouchPhase.Began &&
						(Mathf.Abs ((newPos - player.transform.position).magnitude) < 0.5);
					if (firstTouch || alreadyDragging) {
						player.transform.position = newPos;
						alreadyDragging = true;
					}
				}
			}
		}

		if (Input.touches.Length == 0 && alreadyDragging) {
			alreadyDragging = false;
		}
	}

	void catchSwipes() {
		
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
