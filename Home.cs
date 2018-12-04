using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Home : MonoBehaviour {
	
	public string GameName = "UFO 2.0";
	public string HowToPlayScene = "How_To_Play";
	public string GameScene = "Game";
	public AudioClip menuMusic;
	private Canvas canvas;
	private LevelManager levelManager;
	private MusicManager musicManager;
	private AudioSource homeAudioSource;

	public AudioClip buttonPressSound;

	void Awake() {
		homeAudioSource = gameObject.AddComponent<AudioSource> () as AudioSource;
		homeAudioSource.clip = buttonPressSound;
		canvas = FindObjectOfType<Canvas> ();
		levelManager = FindObjectOfType<LevelManager> ();
		if (levelManager == null) {
			levelManager = new GameObject ().AddComponent (typeof(LevelManager)) as LevelManager;
		}
		musicManager = FindObjectOfType<MusicManager> ();
		if (musicManager == null) {
			musicManager = new GameObject ().AddComponent (typeof(MusicManager)) as MusicManager;
			musicManager.SetBackgroundMusic (menuMusic);
			musicManager.Play ();
		}
		DontDestroyOnLoad (levelManager);
		DontDestroyOnLoad (musicManager);
	}

	public void TransitionHowTo() {
		homeAudioSource.Play ();
		Invoke ("LoadHowTo", 0.2f);
	}

	public void TransitionGame() {
		homeAudioSource.Play ();
		Invoke ("LoadGame", 0.2f);
	}

	private void LoadHowTo() {
		levelManager.Load (HowToPlayScene);
	}

	private void LoadGame() {
		levelManager.Load (GameScene);
	}
}
