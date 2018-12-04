using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleCollision : MonoBehaviour {

	private PlayerAudioManager playerAudioManager;
	private MusicManager musicManager;
	private GroundSpawn groundSpawn;
	private Transform ufo;
	private Rigidbody rbd;
	private ParticleSystem explosionSystem;
	private ParticleSystem smokeSystem;
	private Animator explosionAnimator;
	private AbductorCollision abductorCollision;
	private PlayerMovement playerMovement;
	private Game game;

	void Awake() {
		game = FindObjectOfType<Game> ();
		groundSpawn = FindObjectOfType<GroundSpawn> ();
		abductorCollision = FindObjectOfType<AbductorCollision> ();
		ufo = transform;
		rbd = ufo.gameObject.GetComponent<Rigidbody>() as Rigidbody;
		playerMovement = ufo.gameObject.GetComponent <PlayerMovement>() as PlayerMovement;
		playerAudioManager = ufo.gameObject.GetComponent<PlayerAudioManager> () as PlayerAudioManager;
		explosionSystem = ufo.Find("UFOExplosionSystem").GetComponent<ParticleSystem>();
		smokeSystem = ufo.Find ("UFOSmokeSystem").GetComponent <ParticleSystem> ();
		explosionAnimator = ufo.GetComponent<Animator> ();
	}

	void Start() {
		musicManager = FindObjectOfType<MusicManager> ();
	}

	void Explode() {
		explosionAnimator.SetBool ("isExploding", true);
		musicManager.Stop ();
		playerAudioManager.Explode ();
		explosionSystem.Play ();
		Invoke ("Smoke", 0.2f);
		playerMovement.canMove = false;
		rbd.isKinematic = true;
		game.GameOver ();
	}

	void Smoke() {
		smokeSystem.Play ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "SpawnCollider") {
			groundSpawn.Spawn ();
		}
		if (other.gameObject.layer == 10) {
			Explode ();
		}
		if (other.gameObject.layer == 9) {
			abductorCollision.Abducted (other.gameObject);
		}
	}
}
