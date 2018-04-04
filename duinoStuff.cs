using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uniduino;

public class duinoStuff : MonoBehaviour {

	public Arduino arduino;
	TextMesh remote;

	// Use this for initialization
	void Start () {

		arduino = Arduino.global;
		arduino.Setup (ConfigurePins);

		remote = GameObject.Find("RemoteNumbers").GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		if (remote.text == "5555") {
			StartCoroutine (BlinkLoop ());
		}
	}
	void ConfigurePins(){
		arduino.pinMode (9, PinMode.OUTPUT);
	}

	IEnumerator BlinkLoop() {
		while(true) {   
			arduino.digitalWrite(9, Arduino.HIGH); // led ON
			yield return new WaitForSeconds(1);
			arduino.digitalWrite(9, Arduino.LOW); // led OFF
			yield return new WaitForSeconds(1);
		}           
	}
}
