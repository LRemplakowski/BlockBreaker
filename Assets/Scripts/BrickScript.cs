using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour {

	public AudioClip crack;
	public Sprite [] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;

	private int timesHit;
	private LevelManagerScript levelManager;
	private bool isBreakable;
	private int maxHits;
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakableCount++;
			Debug.Log(breakableCount);
		}
		
		levelManager = GameObject.FindObjectOfType<LevelManagerScript>();
		timesHit = 0;
		maxHits = hitSprites.Length + 1;
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D collision) {
		if (!SoundControllerScript.brickMute) {AudioSource.PlayClipAtPoint (crack, transform.position, 1f);}
		if (isBreakable) {HandleHits ();}
	}
	
	// Method for handling hits
	void HandleHits () {
		timesHit++;			// Increment how many times particular brick got hit
//		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {		
			breakableCount--;
			Debug.Log (breakableCount);
			levelManager.BrickDestroyed();
			PuffSmoke ();
			Destroy(gameObject);
		} else {
			int spriteIndex = timesHit - 1;
			if (hitSprites[spriteIndex]) {
				this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
			} else {Debug.LogError ("Missing sprite!");}
		}
	}
	
	void PuffSmoke () {
//		smoke.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
		GameObject smokePuff = Instantiate (smoke, transform.position, Quaternion.identity) as GameObject;
		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
		Debug.Log ("Particle smoke instantiated!");
	}
}
