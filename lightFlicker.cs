using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightFlicker : MonoBehaviour {

	Light myLight;
	public float minFlickerSpeed = 0.1f;
	public float maxFlickerSpeed = 1.0f;
	int rando;
	GameObject sphere;

	// Use this for initialization
	void Start () {
		rando = Random.Range (1, 6);
		myLight = GetComponent<Light>();
		StartCoroutine (Flicker ());
		sphere = GameObject.Find ("Sphere");
	}

	void Update () {


	}

	// Update is called once per frame
	IEnumerator Flicker () {
		while (true) {
			
			yield return new WaitForSeconds (Random.Range (1f,10f));
		
			for(int i=0;i<rando;i++){
			yield return new WaitForSeconds (Random.Range (minFlickerSpeed, maxFlickerSpeed));
			myLight.enabled = !myLight.enabled;
				sphere.SetActive(!sphere.activeInHierarchy);
			}
			rando = Random.Range (1, 6);
		}
	}
}

