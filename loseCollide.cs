using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Uniduino;

public class loseCollide : MonoBehaviour {

	public Arduino arduino;
	public int pin = 9;
	public int pin2 = 11;
	public GameObject woman;
	Text winText;
	AudioSource dissapoint;

	// Use this for initialization

	void Start () {
		dissapoint = GameObject.Find("dissapoint").GetComponent <AudioSource> ();
		//winText = GameObject.FindGameObjectWithTag ("winText").GetComponent<Text>();

		arduino = Arduino.global;
		arduino.Setup (ConfigurePins);
	}
	
	// Update is called once per frame
	void Update () {


	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "baddie") {
			//winText.enabled = true;
			arduino.analogWrite (pin, 20);
			arduino.analogWrite (pin2, 160);
			dissapoint.enabled = true;
			woman.SetActive (false);
			StartCoroutine (exit ());

		}
	}
	IEnumerator exit() {
		yield return new WaitForSeconds (4);
		SceneManager.LoadScene (0);
	}

	void ConfigurePins(){
		arduino.pinMode (9, PinMode.SERVO);
		arduino.pinMode (11, PinMode.SERVO);
	}
}
