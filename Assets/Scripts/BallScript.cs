using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	public bool hasStarted = false;	

	private PaddleScript paddle;	
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<PaddleScript>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		
		if (SoundControllerScript.ballMute) {
			AudioSource ballSource;
			ballSource = this.GetComponent<AudioSource>();
			ballSource.mute = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {	
			this.transform.position = paddle.transform.position + paddleToBallVector;
				
			if (Input.GetMouseButtonDown(0)) {
				print ("Mouse clicked, ball launched");
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2 (2f, 10f);
			}
		}
	}
	
	void OnCollisionEnter2D (Collision2D ballCollision) {
		Vector2 tweak = new Vector2 (Random.Range (-0.15f, 0.15f), Random.Range (0f, 0.05f));
		if (hasStarted) {
			audio.Play ();
			this.rigidbody2D.velocity += tweak;
		}
		print (tweak);
	}
}
