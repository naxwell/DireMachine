using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightsOut : MonoBehaviour {

	Light overhead;
	// Use this for initialization
	void Start () {
		overhead = GameObject.Find ("Spotlight").GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if (overhead.enabled == true) {
			overhead.enabled = false;
		}
	}
}
