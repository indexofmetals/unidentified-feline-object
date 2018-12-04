using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbductorCollision : MonoBehaviour {

	public float abductionSpeed = 0.001f;

	private bool isAbducting;
	private List<GameObject> lilGuys; // allow for multiple simultaneous abductions
	private Animator animator;
	private PlayerAudioManager playerAudioManager;
	private ScoreBoard scoreBoard;
	private Game game;

	void Start() {
		playerAudioManager = transform.parent.gameObject.GetComponent<PlayerAudioManager> () as PlayerAudioManager;
		animator = gameObject.GetComponent<Animator> (); 
		scoreBoard = FindObjectOfType<ScoreBoard> ();
		game = FindObjectOfType<Game> ();
		lilGuys = new List<GameObject> ();
	}

	void Abduct(GameObject guy) {
		lilGuys.Add (guy);
		isAbducting = true;
		animator.SetBool ("isAbducting", isAbducting);
		scoreBoard.Increment ();
	}


	public void Abducted(GameObject lilGuy) {
		Destroy (lilGuy);
		isAbducting = false;
		animator.SetBool ("isAbducting", isAbducting);
	}

	void FixedUpdate() {
		if (lilGuys.Count > 0) {
			foreach (GameObject lilGuy in lilGuys) {
				if (lilGuy != null) {
					lilGuy.transform.position += (gameObject.transform.position - lilGuy.transform.position) * abductionSpeed;
				}
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		GameObject lilGuy = other.gameObject;
		if (other.gameObject.layer == 9 && game.gameOn) {
			lilGuys.Remove (lilGuy);
			Abduct (lilGuy);
			playerAudioManager.Abduct ();
		}
	}
}
