using UnityEngine;
using System.Collections;

public class EnemySteer : EnemyMove {

	public Transform target;
	public float leash;
	public float accelmin;
	public float accelamount;
	public float velocitymax;

	private Vector3 vel;
	private Vector3 pos;

	// Use this for initialization
	void Start () {
		vel = this.rigidbody2D.velocity = new Vector3 (0f, 0f);
		pos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Update");
		UpdatePrev ();

		if ((pos - target.position).magnitude > leash) {
			if (vel.magnitude < accelmin)
			{
				vel = (target.position - pos).normalized * accelmin;
				//Debug.Log (1);
			}
			else
			{
				vel += (target.position - pos).normalized * accelamount;
				//Debug.Log (2);
			}
			if (vel.magnitude > velocitymax)
			{
				vel = vel.normalized * velocitymax;
				//Debug.Log (3);
			}
		}
		else {
			if (vel.magnitude < accelmin)
			{
				vel = Vector3.zero;
				//Debug.Log (4);
			}
			else
			{
				vel -= (target.position - pos).normalized * accelamount;
				//Debug.Log (5);
			}
		}
		this.rigidbody2D.velocity = vel;
		Debug.Log (vel);
	}
}
