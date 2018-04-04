using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class listenerWithEnabler : MonoBehaviour {
	public GameObject Rotator;
	public GameObject TV;
	public VideoClip videoClip;

	public Vector3 TriggerRotation;
	public float AngleGiveForMatching;
	public float TriggerTime = 3f;
	float targetTime;
	[SerializeField]
	private bool timing;
	[SerializeField]
	private bool playing;
	[SerializeField]
	private bool sameRotation;
	private AudioSource audioPlayer;
	private VideoPlayer videoPlayer;
	private VideoClip ogVideoClip;
	MonoBehaviour lightsOut;

	// Use this for initialization
	void Start () {
		targetTime = TriggerTime;
		audioPlayer = this.GetComponent<AudioSource> ();
		videoPlayer = TV.GetComponent<VideoPlayer> ();
		lightsOut = gameObject.GetComponent<lightsOut> ();
	}

	// Update is called once per frame
	void Update () {

		Quaternion rotationBase = Quaternion.Euler (TriggerRotation.x, TriggerRotation.y, TriggerRotation.z);
		float angle = Quaternion.Angle (rotationBase, Rotator.transform.localRotation);
		sameRotation = Mathf.Abs (angle) < AngleGiveForMatching;

		if (sameRotation & !timing & !playing) {
			timing = true;
		}
		if (!sameRotation) {
			timing = false;
			playing = false;
			audioPlayer.Stop ();
			targetTime = TriggerTime;
			if (ogVideoClip) {
				videoPlayer.clip = ogVideoClip;
				ogVideoClip = null;
			}
		}
		if (timing) {
			targetTime -= 0.1f;
			if (timing && targetTime <= 0.0f) {
				timing = false;
				playing = true;
				audioPlayer.Play ();
				ogVideoClip = videoPlayer.clip;
				videoPlayer.clip = videoClip;
				videoPlayer.Play ();
				targetTime = TriggerTime;
				StartCoroutine (lights ());
			} 
				
		}
	}

	public void PlayingCallBack () {
		audioPlayer.Stop ();
	}

	IEnumerator lights (){
		lightsOut.enabled = true;
		yield return new WaitForSeconds (4);
		lightsOut.enabled = false;
	}
}
