using UnityEngine;
using System.Collections;

public class LevelControl : MonoBehaviour {

	public GameObject BackgroundAudio;
	public GameObject EndingAudio;
	public GameObject Narration;
	public GameObject Fader;

	public float fadeDuration = 6.00f;
	public AudioClip winSound;
	public AudioClip loseSound;

	void Awake() {
		BackgroundAudio = GameObject.Find("BackgroundAudio");
		EndingAudio = GameObject.Find("EndingAudio");
		Narration = GameObject.Find("Narration");
		Fader = GameObject.Find ("Fader");
		Debug.Log("Resolution: ( " + Screen.currentResolution.height.ToString() + " , " + Screen.currentResolution.width.ToString() + " )");
	}
	// Use this for initialization
	void Start () {
		Fader.transform.position += new Vector3(0,0,101);
		StartCoroutine("FadeIn");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void win() {
		StartCoroutine("FadeOutWhite");
	}

	public void lose() {
		StartCoroutine("FadeOutBlack");
	}

	IEnumerator FadeOutBlack() {
		float fadingTime = 0.00f;
		EndingAudio.GetComponent<AudioSource>().clip = loseSound;
		EndingAudio.GetComponent<AudioSource>().Play();
		while(fadingTime <= fadeDuration-3) {
			fadingTime += Time.deltaTime;
			if(fadingTime <= 2.00) {
				BackgroundAudio.GetComponent<AudioSource>().volume = Mathf.Lerp(0.75f, 0.00f, fadingTime/2);
			}
			else {
				BackgroundAudio.GetComponent<AudioSource>().volume = 0;
			}
			Color color = Color.black;
			color.a = Mathf.Lerp(0.00f, 1.00f, fadingTime/(fadeDuration-3));
			Fader.renderer.material.color = color;
			yield return null;
		}
		Application.LoadLevel("Lose");
	}

	IEnumerator FadeOutWhite() {
		float fadingTime = 0.00f;
		EndingAudio.GetComponent<AudioSource>().clip = winSound;
		EndingAudio.GetComponent<AudioSource>().Play();
		while(fadingTime <= fadeDuration) {
			fadingTime += Time.deltaTime;
			if(fadingTime <= 2.00) {
				BackgroundAudio.GetComponent<AudioSource>().volume = Mathf.Lerp(0.75f, 0.00f, fadingTime/2);
			}
			else {
				BackgroundAudio.GetComponent<AudioSource>().volume = 0;
			}
			Color color = Color.white;
			color.a = Mathf.Lerp(0.00f, 1.00f, fadingTime/fadeDuration);
			Fader.renderer.material.color = color;
			yield return null;
		}
		Application.LoadLevel(Application.loadedLevel+1);
	}

	IEnumerator FadeIn() {
		for (float i = 1.00f; i >= 0; i -= 0.01f) {
			Color color = Fader.renderer.material.color;
			color.a = i;
			Fader.renderer.material.color = color;
			yield return null;
		}
//		yield return null;
	}
}
