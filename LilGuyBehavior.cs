using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilGuyBehavior : MonoBehaviour {
	public float runningMin = 0.8f;
	public float runningMax = 1.2f;

	private float runningSpeed;
	private bool isRunning = false;
	private Animator lilGuyAnimator;

	void Awake() {
		GameObject lilGuy = transform.Find ("Lil_Guy").gameObject;
		lilGuyAnimator = lilGuy.GetComponent<Animator> ();
		isRunning = true;
		lilGuyAnimator.SetBool ("isRunning", isRunning);
		runningSpeed = Random.Range (runningMin, runningMax);
		lilGuyAnimator.speed = runningSpeed;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "AbductorCollider") {
			isRunning = false;
			lilGuyAnimator.SetBool ("isRunning", isRunning);
			lilGuyAnimator.SetBool ("isBeingAbducted", true);
		}
	}

	void FixedUpdate() {
		if (isRunning) {
			gameObject.transform.position += new Vector3 (runningSpeed * 0.07f, 0f, 0f);
		}
	}
}
