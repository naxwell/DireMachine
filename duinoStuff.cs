using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uniduino;

public class duinoStuff : MonoBehaviour {

	public Arduino arduino;
	public int pin = 9;
	public int pin2 = 11;
	//TextMesh remote;

	// Use this for initialization
	void Start () {

		arduino = Arduino.global;
		arduino.Setup (ConfigurePins);

	//	remote = GameObject.Find("RemoteNumbers").GetComponent<TextMesh>();
		//StartCoroutine (BlinkLoop ());
	}
	
	// Update is called once per frame
	void Update () {
		//if (remote.text == "5555") {
		//	StartCoroutine (BlinkLoop ());
		//}
	}
	void ConfigurePins(){
		arduino.pinMode (9, PinMode.SERVO);
		arduino.pinMode (11, PinMode.SERVO);
	}

	IEnumerator BlinkLoop() {
		while(true) {   
			arduino.analogWrite(pin,105);
			arduino.analogWrite(pin2, 75);
			yield return new WaitForSeconds(1);
			//arduino.analogWrite(pin, 45);
			//arduino.analogWrite(pin2,135);
			//yield return new WaitForSeconds(1);
		}           
	}
}
