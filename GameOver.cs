using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	public AudioClip menuMusic;
	public AudioClip buttonPressSound;

	private GameObject scoreObj;
	private LevelManager levelManager;
	private ScoreBoard scoreBoard;
	private MusicManager musicManager;
	private AudioSource gameOverAudioSource;

	void Awake() {
		levelManager = FindObjectOfType<LevelManager> ();
		scoreBoard = FindObjectOfType<ScoreBoard> ();
		musicManager = FindObjectOfType<MusicManager> ();
		gameOverAudioSource = gameObject.AddComponent<AudioSource> () as AudioSource;
		gameOverAudioSource.clip = buttonPressSound;
		if (levelManager == null) {
			levelManager = new GameObject ().AddComponent<LevelManager> () as LevelManager;
		}
		if (musicManager == null) {
			musicManager = new GameObject ().AddComponent<MusicManager> () as MusicManager;
			DontDestroyOnLoad (musicManager);
		} 
		if (scoreBoard == null) {
			scoreBoard = new GameObject ().AddComponent<ScoreBoard> () as ScoreBoard;
		}
		scoreBoard.scoreText = scoreBoard.GetScoreTextObj ();
		scoreBoard.highScoreText = scoreBoard.GetHighScoreTextObj ();
		scoreBoard.SetText ();
		musicManager.SetBackgroundMusic (menuMusic);
		musicManager.Play ();
	}

	public void TransitionPlayAgain() {
		gameOverAudioSource.Play ();
		Invoke ("PlayAgain", 0.3f);
	}

	public void TransitionBackToMainMenu() {
		gameOverAudioSource.Play ();
		Invoke ("BackToMainMenu", 0.3f);
	}

	private void PlayAgain() {
		levelManager.Load ("Game");
	}

	private void BackToMainMenu() {
		levelManager.Load ("Menu");
	}

}
