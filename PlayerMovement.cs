using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public Vector3 initialPlayerPosition = new Vector3(1.3f, 9f, 0f);
	public AudioClip flyingNoise;

	public float maxHeight = 16f;
	public float verticalForce = 4f;
	public float maxVerticalSpeed = 10f;
	public float horizontalSpeed = 0.1f;
	public bool canMove = false;

//	private GameObject ufoColliderObj;
	private GameObject abductorColliderObj;
	private Rigidbody rbd;
	private PlayerAudioManager playerAudioManager;
	private MusicManager musicManager;

	//public float avgFrameRate;

	void Awake () {
		playerAudioManager = gameObject.GetComponent<PlayerAudioManager> () as PlayerAudioManager;
		musicManager = FindObjectOfType<MusicManager> () as MusicManager;
		if (musicManager == null) {
			musicManager = new GameObject ().AddComponent (typeof(MusicManager)) as MusicManager;
		}
//		ufoColliderObj = gameObject.transform.Find ("UFOCollider").gameObject;
		abductorColliderObj = gameObject.transform.Find ("AbductorCollider").gameObject;
		rbd = gameObject.GetComponent<Rigidbody> ();
		rbd.transform.position = initialPlayerPosition;
	}

	void FixedUpdate() {
		if (canMove) {
			if(Input.touchCount > 0 || Input.GetMouseButton(0)) {
				playerAudioManager.increasePitch ();
				if(transform.position.y < maxHeight) {
					Levitate();
				}
			} else {
				playerAudioManager.decreasePitch ();
			}
			if (rbd.velocity.magnitude > maxVerticalSpeed) {
				rbd.velocity = rbd.velocity.normalized * maxVerticalSpeed;
			}
			transform.position = new Vector3 (transform.position.x + horizontalSpeed, Mathf.Clamp (rbd.transform.position.y, 0f, maxHeight), rbd.transform.position.z);
			abductorColliderObj.transform.position = rbd.transform.position - new Vector3(0f, 0.05f, 0f);
		}
	}

	void Levitate () {
		rbd.velocity += new Vector3(0f, verticalForce, 0f);
	}
}
