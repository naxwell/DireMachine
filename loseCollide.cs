using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loseCollide : MonoBehaviour {


	Text winText;

	// Use this for initialization
	void Start () {

		winText = GameObject.FindGameObjectWithTag ("winText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {


	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "baddie") {
			winText.enabled = true;
		}
	}
}
