using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
	private AudioSource musicPlayer;

	void Awake() {
		musicPlayer = gameObject.GetComponent<AudioSource> ();
		if (musicPlayer == null) {
			musicPlayer = gameObject.AddComponent<AudioSource> ();
		}
		SetVolume (1.0f);
		musicPlayer.loop = true;
	}

	public void Play() {
		musicPlayer.Play ();
	}

	public void Stop() {
		musicPlayer.Stop ();
	}

	void SetVolume(float volume) {
		musicPlayer.volume = volume;
	}

	public void SetBackgroundMusic(AudioClip music) {
		musicPlayer.clip = music;
	}
}
