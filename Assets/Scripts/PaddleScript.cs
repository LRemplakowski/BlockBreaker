using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour {

	public bool autoPlay;
	public float minX, maxX;
	
	private BallScript ball;
	
	void Start () {
		ball = GameObject.FindObjectOfType <BallScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay || !ball.hasStarted) {	
			MoveWithMouse();
		} else {
			AutoMode();
		}
	}
	
	void MoveWithMouse () {
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);	
		paddlePos.x = Mathf.Clamp (mousePosInBlocks, minX, maxX);
		this.transform.position = paddlePos;
	}
	
	void AutoMode () {	
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp (ballPos.x, minX, maxX);
		this.transform.position = paddlePos;
	}
}
