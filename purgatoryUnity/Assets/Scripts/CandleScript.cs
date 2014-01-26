using UnityEngine;
using System.Collections;

public class CandleScript : MonoBehaviour {
	AudioSource audioSource;
	float flicker = 0.00f;
	public float flickerTime = 0.80f;
	public GameObject glow;
	public enum CandleState {UNLIT, LIGHTING, BURNING, EXTINGUISHING};
	CandleState state;

	public enum CandleType {PLAYER, GHOST, ENEMY};
	public CandleType type;

	void Awake() {
		audioSource = this.gameObject.GetComponent<AudioSource>();
	}
	// Use this for nitialization
	void Start () {
		Light();
	}
	
	// Update is called once per frame
	void Update () {
//		If you want to test the candle, uncomment this
//		if(Input.GetKey(KeyCode.Space)) {
//			if(state == CandleState.BURNING)
//				Extinguish();
//			if(state == CandleState.UNLIT)
//				Light();
//		}
		if(type == CandleType.PLAYER) {
			if (Input.GetMouseButton(0)) {
				if(state == CandleState.UNLIT)
					Light();
			}
			else {
				if(state == CandleState.BURNING)
					Extinguish();
			}
		}

		flicker += Time.deltaTime;
		switch (state) {
			case CandleState.LIGHTING:
				glow.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one * 0.75f, flicker/0.50f);
				if(flicker >= 0.50f) {
					flicker = 0.00f;
					state = CandleState.BURNING;
				}
				break;

			case CandleState.BURNING:
				glow.transform.localScale = (Vector3.one * 0.75f) + (Vector3.one * 0.25f * Mathf.Sin(flicker/flickerTime));
				break;

			case CandleState.EXTINGUISHING:
				glow.transform.localScale = Vector3.Lerp(glow.transform.localScale, Vector3.zero, flicker/0.50f);
				if(flicker >= 0.50f) {
					flicker = 0.00f;
					state = CandleState.UNLIT;
				}
				break;

			case CandleState.UNLIT:
				break;
		}
	}

	public void Light() {
		if(state == CandleState.UNLIT || state == CandleState.EXTINGUISHING) {
			flicker = 0.00f;
			audioSource.clip = Resources.Load("epitaph-candleon") as AudioClip;
			audioSource.Play();
			glow.transform.localScale = Vector3.zero;
			state = CandleState.LIGHTING;
		}
	}

	public void Extinguish() {
		if(state == CandleState.BURNING || state == CandleState.LIGHTING) {
			flicker = 0.00f;
			audioSource.clip = Resources.Load("epitaph-candleoff") as AudioClip;
			audioSource.Play();
			state = CandleState.EXTINGUISHING;
		}
	}
	public CandleState getCandleState() {
		return state;
	}

	public void setGlow(GameObject _glow) {
		glow = _glow;
	}
}
