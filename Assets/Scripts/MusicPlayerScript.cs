using UnityEngine;
using System.Collections;

public class MusicPlayerScript : MonoBehaviour {

	public static MusicPlayerScript Instance = null;

	// Use this for initialization
	void Awake () {	
		if (Instance != null) {
			Destroy (gameObject);
			print ("Duplicate Music Player self-destructing!");
		} else {
			GameObject.DontDestroyOnLoad (gameObject);
			Instance = this;
		}
	}	
}
