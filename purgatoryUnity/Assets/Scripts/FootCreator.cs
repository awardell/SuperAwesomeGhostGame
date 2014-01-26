using UnityEngine;
using System.Collections;

public class FootCreator : MonoBehaviour {

	float spawnTimer = 0.0f;
	float spawnRate = 0.5f;
	bool spawnLeft = true;
	public float offset = -1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		spawnTimer += Time.deltaTime;
		if(spawnTimer >= spawnRate) {
			GameObject tempFoot;
			Vector3 footLoc;
			float angle = Vector3.Angle(Vector3.up, this.rigidbody2D.velocity);
			if(this.rigidbody2D.velocity.x > 0)
				angle *= -1;
			Quaternion footRot = Quaternion.Euler(new Vector3(0, 0, angle));
			footLoc = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1);
			if(spawnLeft) {
				tempFoot = (GameObject)Instantiate(Resources.Load("Foot"), footLoc, footRot);
			}
			else {
				tempFoot = (GameObject)Instantiate(Resources.Load("Foot"), footLoc, footRot);
				tempFoot.transform.localScale = new Vector3(tempFoot.transform.localScale.x * -1, tempFoot.transform.localScale.y, tempFoot.transform.localScale.z);
			}

			spawnLeft = !spawnLeft;
			spawnTimer = 0.0f;
		}
	}
}
