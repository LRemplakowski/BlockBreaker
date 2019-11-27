using UnityEngine;
using System.Collections;

public class SoundControllerScript : MonoBehaviour {

	public static bool brickMute = false;	
	public static bool ballMute = false;
	
	private MusicPlayerScript musicPlayer;
	private AudioSource musicSource;
	private AudioSource ballSource;
	
	void Start () {
		musicPlayer = GameObject.FindObjectOfType<MusicPlayerScript>();
	}
		
	public void MusicToggle () {
		musicSource = musicPlayer.GetComponent<AudioSource>();
		musicSource.mute = !musicSource.mute;
		Debug.Log ("Music toggled!");
	}
	
	public void SoundToggle () {
		ballMute = !ballMute;
		brickMute = !brickMute;
		Debug.Log ("Sound toggled!");
	}
}
