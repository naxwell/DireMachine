using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonPress : MonoBehaviour {

	Vector3 original;
	// Use this for initialization
	void Start () {
		original = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {

		if (OVRInput.Get(OVRInput.RawButton.X)) {
			transform.localPosition = new Vector3 (transform.localPosition.x, 0.4f, transform.localPosition.z);
		} else
			transform.localPosition = original;

	}
}