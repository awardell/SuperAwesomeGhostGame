using UnityEngine;
using System.Collections;

public class GravityWell : MonoBehaviour {
	GameObject[] gameObjects;
	public float gravityStrength = 1.00f;
	public float safetyZone = 0.50f;
	public bool affected = false;

	// Use this for initialization
	void Awake () {
		gameObjects = Object.FindObjectsOfType(typeof(GameObject)) as GameObject[];
	}

	void Start() {

	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject candle in gameObjects) {
			if(candle.name.Contains("Candle") &&
			    Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.y),
				new Vector2(candle.transform.position.x,candle.transform.position.y)) >= safetyZone &&
			    affected){
				float distance = Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(candle.transform.position.x,candle.transform.position.y));
				float force = gravityStrength * candle.GetComponent<GravityWell>().getStrength() / (distance * distance);

				float angle = Vector3.Angle(Vector3.right, candle.transform.position - transform.position);
				if(candle.transform.position.y - gameObject.transform.position.y < 0)
					angle *= -1;
					
				float xForce = gravityStrength * Mathf.Cos(angle * Mathf.PI/180.00f);
				float yForce = gravityStrength * Mathf.Sin(angle * Mathf.PI/180.00f);
				this.rigidbody2D.AddForce(new Vector2(xForce, yForce));
			}
		}
	}

	public float getStrength() {
		return gravityStrength;
	}
}
