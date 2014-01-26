using UnityEngine;
using System.Collections;

public class PlayerKiller : MonoBehaviour {

	public GameObject Player;
	public GameObject Enemy;
	public GameObject mainCam;

	public bool isPit = false;
	public enum ObstacleType {//Might need this to discern the game wall to make sure the ghost doesn't go through that
		NONE,
		PIT,
		WALLEDGE,
		FENCE,
		ENEMY,
	};
	public ObstacleType obstacleType;

	// Use this for initialization
	void Awake () {
		Player = GameObject.FindGameObjectWithTag("Player");
		Enemy = GameObject.FindGameObjectWithTag("Enemy");
		mainCam = GameObject.Find("Camera");
	}

	void Start() {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D collider) {
		if(obstacleType == ObstacleType.FENCE && collider.gameObject.tag == "Enemy") {
//			Enemy.GetComponent<GravityWell>().forceMovement();
			collider.collider.enabled = false;
			StartCoroutine("ReenableCollider");
		}
	}

	IEnumerator ReenableCollider() {
		yield return new WaitForSeconds(1);
		Enemy.collider2D.enabled = true;
	}

	void OnCollisionStay2D(Collision2D collider) {
		if(obstacleType == ObstacleType.FENCE && collider.gameObject.tag == "Enemy") {
//			Enemy.GetComponent<GravityWell>().forceMovement();
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log ("Collided with " + collider.gameObject.tag);

		switch(obstacleType) {
			case ObstacleType.PIT:
				if(collider.gameObject.tag == "Player") {
					mainCam.GetComponent<LevelControl>().lose();
					freezeGame();
				} else if (collider.gameObject.tag == "Enemy") {
					mainCam.GetComponent<LevelControl>().win();
					freezeGame();
//					Application.LoadLevel(Application.loadedLevel+1);
				}
				break;
			case ObstacleType.WALLEDGE:
				if(collider.gameObject.tag == "Player") {
					Player.GetComponent<PlayerController>().stopPlayer();
//					Enemy.GetComponent<EnemyMove>().moveFromCollision();
				}
				else if (collider.gameObject.tag == "Enemy") {
					Enemy.GetComponent<GravityWell>().reverseMovement();
				}
//				Player.GetComponent<PlayerController>().stopPlayer();
				break;
			case ObstacleType.FENCE:
				if(collider.gameObject.tag == "Player") {
					Player.GetComponent<PlayerController>().stopPlayer();
//					Enemy.GetComponent<EnemyMirror>().moveFromCollision();
				}
				else if (collider.gameObject.tag == "Enemy") {
//					Enemy.GetComponent<GravityWell>().forceMovement();
				}
			break;
			case ObstacleType.ENEMY:
				if(collider.gameObject.tag == "Player" || collider.gameObject.tag == "Enemy") {
					mainCam.GetComponent<LevelControl>().lose();
					freezeGame();
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

	void freezeGame() {
		Enemy.GetComponent<GravityWell>().affected = false;
		Player.rigidbody2D.velocity = Vector3.zero;
		Player.GetComponent<PlayerController>().enabled = false;
		Enemy.rigidbody2D.velocity = Vector3.zero;
		Enemy.GetComponent<EnemyMirror>().enabled = false;
		Enemy.GetComponent<FootCreator>().enabled = false;
	}
}
