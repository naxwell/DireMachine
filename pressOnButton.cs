using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressOnButton : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (OVRInput.Get (OVRInput.Button.One)) {
			gameObject.transform.localPosition = new Vector3 (-0.254f, -0.04f, 0.013f);
		
		} else
			gameObject.transform.localPosition = new Vector3 (-0.254f, -0.013f, 0.013f);
	}
}
