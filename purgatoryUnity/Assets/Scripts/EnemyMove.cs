using UnityEngine;
using System.Collections;

public abstract class EnemyMove : MonoBehaviour {

	public Transform player;
	
	public Vector3 prevPos;

	public void moveFromCollision() {
		this.transform.position = prevPos;
	}

	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	//note: make sure to explicitly call this from derived class updates
	protected void UpdatePrev()
	{
		prevPos = this.transform.position;
	}
}
