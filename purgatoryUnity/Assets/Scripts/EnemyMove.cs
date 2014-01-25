using UnityEngine;
using System.Collections;

public abstract class EnemyMove : MonoBehaviour {

	public Transform player;
	
	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
}
