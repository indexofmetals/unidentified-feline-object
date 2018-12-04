using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToUI : MonoBehaviour {

	public AudioClip menuMusic;
	public AudioClip buttonPressSound;

	private Animator abductorAnimator;
	private Animator playerAnimator;
	private GameObject playerHowTo;
	private GameObject abductorCollider;
	private LevelManager levelManager;
	private MusicManager musicManager;
	private AudioSource howToAudioSource;

	void Awake() {
		playerHowTo = GameObject.Find ("Player_How_To");
		playerAnimator = playerHowTo.GetComponent<Animator> ();
		playerAnimator.SetBool ("isHowTo", true);
		abductorCollider = playerHowTo.transform.Find ("AbductorCollider").gameObject;
		abductorAnimator = abductorCollider.GetComponent<Animator> ();
		abductorAnimator.speed = 0.25f;
		abductorAnimator.SetBool ("isHowTo", true);
		levelManager = FindObjectOfType<LevelManager> ();
		howToAudioSource = gameObject.AddComponent<AudioSource> () as AudioSource;
		howToAudioSource.clip = buttonPressSound;
		if (levelManager == null) {
			levelManager = new GameObject ().AddComponent (typeof(LevelManager)) as LevelManager;
		}
		musicManager = FindObjectOfType<MusicManager> ();
		if (musicManager == null) {
			musicManager = new GameObject ().AddComponent (typeof(MusicManager)) as MusicManager;
			DontDestroyOnLoad (musicManager);
			musicManager.SetBackgroundMusic (menuMusic);
			musicManager.Play ();
		}
	}

	public void TransitionExit() {
		howToAudioSource.Play ();
		Invoke ("Exit", 0.3f);
	}

	private void Exit() {
		levelManager.Load ("Menu");
	}
}
