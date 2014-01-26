using UnityEngine;
using System.Collections;

public class FootCreator : MonoBehaviour {

//	float spawnTimer = 0.0f;
//	float spawnRate = 0.5f;
	bool spawnLeft = true;
	public float offset = -1.0f;
	Vector3 lastSpawn;
	public float spawnDistance = 0.50f;
	int footStepNumber = 1;

	void Awake() {
	}

	// Use this for initialization
	void Start () {
	lastSpawn = this.transform.position;
	GameObject tempFoot;
	Vector3 footLoc;
	float angle = Vector3.Angle(Vector3.up, this.rigidbody2D.velocity);
	if(this.rigidbody2D.velocity.x > 0)
		angle *= -1;
	Quaternion footRot = Quaternion.Euler(new Vector3(0, 0, angle));
	footLoc = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1);
	tempFoot = (GameObject)Instantiate(Resources.Load("Foot"), footLoc, footRot);
	tempFoot = (GameObject)Instantiate(Resources.Load("Foot"), footLoc, footRot);
	tempFoot.transform.localScale = new Vector3(tempFoot.transform.localScale.x * -1, tempFoot.transform.localScale.y, tempFoot.transform.localScale.z);
	}
	
	// Update is called once per frame
	void Update () {
//		spawnTimer += Time.deltaTime;
//		if(spawnTimer >= spawnRate) {
		if(Vector3.Distance(this.transform.position, lastSpawn) > spawnDistance) {
			lastSpawn = this.transform.position;
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
			StartCoroutine("playFootstep");
			spawnLeft = !spawnLeft;
//			spawnTimer = 0.0f;
		}
	}

	IEnumerator playFootstep() {
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = Resources.Load("step"+footStepNumber.ToString()) as AudioClip;
		audioSource.Play();

		footStepNumber ++;
		if(footStepNumber > 4) {
			footStepNumber = 1;
		}

		yield return new WaitForSeconds(2);
		Destroy(audioSource);
	}
}
