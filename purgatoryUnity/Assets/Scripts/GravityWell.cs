using UnityEngine;
using System.Collections;

public class GravityWell : MonoBehaviour {
	GameObject[] gameObjects;
	public float gravityStrength = 1.00f;
	public float safetyZone = 0.50f;
	public bool affected = false;
	public float speed = 0.20f;

	// Use this for initialization
	void Awake () {
		gameObjects = Object.FindObjectsOfType(typeof(GameObject)) as GameObject[];
	}

	void Start() {

	}
	
	// Update is called once per frame
	void Update () {
		Vector2 direction = Vector2.zero;
		if(affected) {
			foreach(GameObject candle in gameObjects) {
	//			if(candle.name.Contains("Candle") &&
	//			    Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.y),
	//				new Vector2(candle.transform.position.x,candle.transform.position.y)) >= safetyZone &&
	//			    affected){
	//				float distance = Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(candle.transform.position.x,candle.transform.position.y));
	//				float force = gravityStrength * candle.GetComponent<GravityWell>().getStrength() / (distance * distance);
	//
	//				float angle = Vector3.Angle(Vector3.right, candle.transform.position - transform.position);
	//				if(candle.transform.position.y - gameObject.transform.position.y < 0)
	//					angle *= -1;
	//					
	//				float xForce = gravityStrength * Mathf.Cos(angle * Mathf.PI/180.00f);
	//				float yForce = gravityStrength * Mathf.Sin(angle * Mathf.PI/180.00f);
	//				this.rigidbody2D.AddForce(new Vector2(xForce, yForce));
	//			}
				if(candle == gameObject)
					continue;
				if(candle.name.Contains ("Candle")) {
					Vector2 farVector = new Vector3(candle.transform.position.x, candle.transform.position.y);
					Vector2 thisVector = new Vector3(transform.position.x, transform.position.y);

					if(candle.name.Contains("PlayerCandle")) {
						if(candle.GetComponent<CandleScript>().getCandleState() == CandleScript.CandleState.BURNING) {
							direction += (farVector - thisVector).normalized;
							direction += (farVector - thisVector).normalized;
						}
					}
					else {
						direction += (farVector - thisVector).normalized;
					}
					
				}
			}
			if(direction.magnitude <= 0.1f) {
				rigidbody2D.velocity = Vector2.zero;
			}
			else {
				direction.Normalize();
				float angle = Vector2.Angle(Vector2.right, direction);					
				float xVel = speed * Mathf.Cos(angle * Mathf.PI/180.00f);
				float yVel = speed * Mathf.Sin(angle * Mathf.PI/180.00f);
				if(direction.y < 0)
					yVel *= -1;
				rigidbody2D.velocity = new Vector2(xVel, yVel);
			}
		}
	}

	public float getStrength() {
		return gravityStrength;
	}
}
