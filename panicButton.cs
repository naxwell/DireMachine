using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using Uniduino;

public class panicButton : MonoBehaviour {
	public TextMesh remoteText;
	public GameObject TV;
	public VideoClip videoClip;
	private VideoPlayer videoPlayer;
	private VideoClip ogVideoClip;

	public Arduino arduino;

	public int pin = 9;
	public int pin2 = 11;
	// Use this for initialization
	void Start () {
		videoPlayer = TV.GetComponent<VideoPlayer> ();

		arduino = Arduino.global;
		arduino.Setup (ConfigurePins);
	}

	// Update is called once per frame
	void Update () {

		if (OVRInput.Get (OVRInput.Button.Three)) {
			gameObject.transform.localPosition = new Vector3 (0f, -0.05f, 0f);
			StartCoroutine (bye ());

		} else
			gameObject.transform.localPosition = new Vector3 (0f, 0f, 0f);
	}
	IEnumerator bye(){
		remoteText.text = "BYE";
		videoPlayer.clip = videoClip;
		videoPlayer.Play ();
		arduino.analogWrite (pin, 20);
		arduino.analogWrite (pin2, 160);
		yield return new WaitForSeconds (3);
		SceneManager.LoadScene (0);
	
	}

	void ConfigurePins(){
		arduino.pinMode (9, PinMode.SERVO);
		arduino.pinMode (11, PinMode.SERVO);
	}

}
