using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadSceneListener : MonoBehaviour {
	public GameObject Rotator;
	public int sceneNum;
	public Vector3 TriggerRotation;
	public float AngleGiveForMatching;
	public float TriggerTime = 3f;
	float targetTime;
	[SerializeField]
	private bool timing;
	[SerializeField]
	private bool sameRotation;

	// Use this for initialization
	void Start () {
		targetTime = TriggerTime;
	}

	// Update is called once per frame
	void Update () {
		Quaternion rotationBase = Quaternion.Euler (TriggerRotation.x, TriggerRotation.y, TriggerRotation.z);
		float angle = Quaternion.Angle (rotationBase, Rotator.transform.localRotation);
		sameRotation = Mathf.Abs (angle) < AngleGiveForMatching;
		if (sameRotation & !timing) {
			timing = true;
		}
		if (!sameRotation) {
			timing = false;
		}
		if (timing) {
			targetTime -= 0.1f;
			if (timing && targetTime <= 0.0f)
			{
				timing = false;
				targetTime = TriggerTime;
				SceneManager.LoadScene (sceneNum);
			}
		}
	}
}