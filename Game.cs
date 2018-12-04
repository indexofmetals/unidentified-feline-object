using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	public ScoreBoard scoreBoard;
	public GameObject ufo;
	public bool gameOn = false;
	public AudioClip gameBackgroundMusic;

	private LevelManager levelManager;
	private PlayerMovement playerMovement;
	private MusicManager musicManager;
	private Rigidbody rbd;

	void Awake() {
		scoreBoard = new GameObject ().AddComponent (typeof(ScoreBoard)) as ScoreBoard;
		DontDestroyOnLoad (scoreBoard);
		playerMovement = ufo.GetComponent<PlayerMovement> ();
		levelManager = FindObjectOfType<LevelManager> ();
		if (levelManager == null) {
			levelManager = new GameObject ().AddComponent (typeof(LevelManager)) as LevelManager;
		}
		musicManager = FindObjectOfType<MusicManager> ();
		if (musicManager == null) {
			musicManager = new GameObject ().AddComponent (typeof(MusicManager)) as MusicManager;
		}
		playerMovement.canMove = false;
		rbd = ufo.GetComponent<Rigidbody> ();
		rbd.isKinematic = true;
	}

	void Start() {
		musicManager.Stop ();
		musicManager.SetBackgroundMusic (gameBackgroundMusic);
		musicManager.Play ();
		CountDown ();
	}

	void CountDown() {
		//Show the countdown
		Invoke ("StartGame", 2.0f);
	}

	void StartGame() {
		playerMovement.canMove = true;
		rbd.isKinematic = false;
		gameOn = true;
	}

	public void GameOver () {
		gameOn = false;
		Invoke ("LoadGameOver", 2.0f);
	}

	void LoadGameOver() {
		levelManager.Load ("Game_Over");
	}
}
