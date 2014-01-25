using UnityEngine;
using System.Collections;

public class PlayerKiller : MonoBehaviour {

	public GameObject Player;
	public GameObject Enemy;

	public bool isPit = false;
	public enum ObstacleType {//Might need this to discern the game wall to make sure the ghost doesn't go through that
		NONE,
		PIT,
		WALLEDGE,
		FENCE
	};
	public ObstacleType obstacleType;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
		Enemy = GameObject.FindGameObjectWithTag("Enemy");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		//Debug.Log ("Collided with " + collider.gameObject.tag);

		switch(obstacleType) {
			case ObstacleType.PIT:
				if(collider.gameObject.tag == "Player") {
					Application.LoadLevel("Lose");
				} else if (isPit && collider.gameObject.tag == "Enemy") {
					Application.LoadLevel(Application.loadedLevel+1);
				}
				break;
			case ObstacleType.WALLEDGE:
				if(collider.gameObject.tag == "Player") {
					Player.GetComponent<PlayerController>().stopPlayer(Player.GetComponent<PlayerController>().GetDirection());
				} else if (collider.gameObject.tag == "Enemy") {
					Player.GetComponent<PlayerController>().stopPlayer(Player.GetComponent<PlayerController>().GetDirection());
				}
//				Player.GetComponent<PlayerController>().stopPlayer();
				break;
			case ObstacleType.FENCE:
				if(collider.gameObject.tag == "Player" || collider.gameObject.tag == "Enemy") {
					Player.GetComponent<PlayerController>().stopPlayer(Player.GetComponent<PlayerController>().GetDirection());
				}
				break;
			default:
				break;
		}


//		if (collider.gameObject.tag == "Player") {
//			Application.LoadLevel("Lose");
//		} else if (isPit && collider.gameObject.tag == "Enemy") {
//			Application.LoadLevel(Application.loadedLevel+1);
//		}

	}
}
