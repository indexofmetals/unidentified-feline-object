using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PrefsManager {

	const string MUSIC_VOLUME = "musicVolume";
	const string SFX_VOLUME = "sfxVolume";
	const string HIGH_SCORE = "highScore";
	const string HAS_SET_VOLUME = "hasSetVolume";

	public static int GetHasSetVolume() {
		return PlayerPrefs.GetInt (HAS_SET_VOLUME);
	}

	public static float GetMusicVolume() {
		return PlayerPrefs.GetFloat (MUSIC_VOLUME);
	}

	public static void SetMusicVolume(float volume){
		PlayerPrefs.SetFloat (MUSIC_VOLUME, volume);
	}

	public static float GetSFXVolume() {
		return PlayerPrefs.GetFloat (SFX_VOLUME);
	}

	public static void SetSFXVolume(float volume) {
		PlayerPrefs.SetFloat (SFX_VOLUME, volume);
	}

	public static int GetHighScore() {
		return PlayerPrefs.GetInt (HIGH_SCORE);
	}

	public static void SetHighScore(int score) {
		PlayerPrefs.SetInt (HIGH_SCORE, score);
	}

	public static void Save() {
		PlayerPrefs.Save ();
	}
}
