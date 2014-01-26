using UnityEngine;
using System.Collections;

public class FootScript : MonoBehaviour {

	float visibleTime = 2.00f;
	float fadeTime = 1.00f;
	float existingTime = 0.00f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		existingTime += Time.deltaTime;
		if(existingTime >= visibleTime) {
			Color tempColor = this.GetComponent<SpriteRenderer>().material.color;
			float alpha = Mathf.Lerp(1.00f, 0.00f, (existingTime - visibleTime)/fadeTime);
			this.GetComponent<SpriteRenderer>().material.color = new Color(tempColor.r, tempColor.g, tempColor.b, alpha);
		}
		if(existingTime > visibleTime + fadeTime) {
			Destroy(gameObject);
		}
	}
}
