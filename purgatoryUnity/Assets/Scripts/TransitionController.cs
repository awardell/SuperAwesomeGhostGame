using UnityEngine;
using System.Collections;

public class TransitionController : MonoBehaviour {

	public string sceneName;
	private AudioSource source;

	void Awake () {
		source = GetComponent<AudioSource> ();
	}

	// Use this for initialization
	void Start () {
		source.Play ();
		Invoke ("LoadNextLevel", source.clip.length + 0.5f);
	}

	private void LoadNextLevel()
	{
		Application.LoadLevel (sceneName);
	}
}
