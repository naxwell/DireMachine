using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uniduino;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class letMeOut : MonoBehaviour {


	public Arduino arduino;
	public int pin = 9;
	public int pin2 = 11;

	public GameObject TV;
	public VideoClip videoClip;
	private VideoPlayer videoPlayer;

	// Use this for initialization


	void Start () {

		arduino = Arduino.global;
		arduino.Setup (ConfigurePins);
		videoPlayer = TV.GetComponent<VideoPlayer> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (OVRInput.GetDown (OVRInput.Button.One)){

		
				
			}

		if (OVRInput.Get (OVRInput.Button.Three)) {
			gameObject.transform.localPosition = new Vector3 (0f, -0.05f, 0f);
			StartCoroutine (bye ());
			arduino.analogWrite (pin, 20);
			arduino.analogWrite (pin2, 160);

		} else
			gameObject.transform.localPosition = new Vector3 (0f, 0f, 0f);
		
	}

	IEnumerator bye(){
		videoPlayer.clip = videoClip;
		videoPlayer.Play ();
		yield return new WaitForSeconds (3);
		SceneManager.LoadScene (0);

	}


	void ConfigurePins(){
		arduino.pinMode (9, PinMode.SERVO);
		arduino.pinMode (11, PinMode.SERVO);
	}

}
