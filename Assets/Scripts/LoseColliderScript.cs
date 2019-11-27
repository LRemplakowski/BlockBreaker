using UnityEngine;
using System.Collections;

public class LoseColliderScript : MonoBehaviour {

	private LevelManagerScript LevelManager;
	
	void Start () {
		LevelManager = GameObject.FindObjectOfType<LevelManagerScript>();
	}

	void OnTriggerEnter2D (Collider2D trigger) {
		Debug.Log ("Trigger happens - Collider2D.");
		
		LevelManager.LoadLevel ("Lose");
	}
}
