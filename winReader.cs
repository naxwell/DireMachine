using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winReader : MonoBehaviour {


	TextMesh remote;

	// Use this for initialization
	void Start () {

		remote = GameObject.Find("RemoteNumbers").GetComponent<TextMesh>();
	
	// Update is called once per frame
	}
	void Update () {
		
		if (remote.text.Length == 5) {
			remote.text = "FAIL";
		}

		if(remote.text == "80085") {
			print ("WINNNNNNNN"); 
		}
	}
}
