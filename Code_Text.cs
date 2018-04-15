using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Uniduino;
using UnityEngine.SceneManagement;


public class Code_Text : MonoBehaviour {

		//public Text codeEntry;
		public GameObject Rotator;
		public TextMesh remoteText;
		private bool firstTime = false;

		public Arduino arduino;
		private int pin = 9;
		private int pin2 = 11;
		//public Vector3 TriggerRotation;
		//public float AngleGiveForMatching;
		//private bool sameRotation;
		private string currentNumber = "0";
		private float rotationAngle;

		void Start()
		{
			//Text sets your text to say this message
			//codeEntry.text = "Enter Code to Escape";
		remoteText.text = "8008";
		//StartCoroutine (duino ());
		arduino = Arduino.global;
		arduino.Setup (ConfigurePins);

		}

	void ConfigurePins(){
		arduino.pinMode (9, PinMode.SERVO);
		arduino.pinMode (11, PinMode.SERVO);
	}


		void Update()
	{

		//Quaternion rotationBase = Quaternion.Euler (TriggerRotation.x, TriggerRotation.y, TriggerRotation.z);
		//float angle = Quaternion.Angle (rotationBase, Rotator.transform.localRotation);
		//sameRotation = Mathf.Abs (angle) < AngleGiveForMatching;
		rotationAngle = Rotator.transform.localRotation.eulerAngles.y;

		//emma
		if (rotationAngle > 130 && rotationAngle < 160) {
			currentNumber = "6";
		}

		//newscast
		if (rotationAngle > 75 && rotationAngle < 105) {
			currentNumber = "1";
		}
		//Gabby
		if (rotationAngle > 320 && rotationAngle < 360) {
			currentNumber = "3";
		}
		//Couple
		if (rotationAngle > 195 && rotationAngle < 225) {
			currentNumber = "5";
		}
		//Preacher
		if (rotationAngle > 0 && rotationAngle < 50) {
			currentNumber = "2";
		}

		//Press the space key to change the Text message

		if (OVRInput.GetDown (OVRInput.Button.One) && firstTime == false) {
			//codeEntry.text = codeEntry.text + currentNumber;
			remoteText.text = "";
			firstTime = true;
		}

		if (OVRInput.GetDown (OVRInput.Button.One) && firstTime == true) {
			//codeEntry.text = codeEntry.text + currentNumber;
			remoteText.text += currentNumber;
		}
			
		if (remoteText.text.Length == 5) {
			remoteText.text = "FAIL";
			firstTime = false;
		}

		if (remoteText.text == "3223") {
			StartCoroutine (win ());
		}

	
	}
		
	IEnumerator win(){
		arduino.analogWrite (pin, 20);
		arduino.analogWrite (pin2, 160);
		remoteText.text = "GOOD";
		yield return new WaitForSeconds (1);
		remoteText.text = "DAY";
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene (0);
		

	}
	}
	
	