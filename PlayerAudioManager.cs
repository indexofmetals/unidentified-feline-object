using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour {
	public float pitchDownRate = 0.01f;
	public float pitchUpRate = 0.2f;
	public float maxPitch = 1.0f;
	public float minPitch = 0.5f;
	public float startPitch = 0.8f;
	public float hoverNoiseMultiplier = 0.65f;
	public AudioClip explosion;
	public AudioClip flyingNoise;
	public AudioClip abductorNoise;

	private AudioSource explosionAudioSource;
	private AudioSource flyingAudioSource;
	private AudioSource abductorAudioSource;

	void Awake() {

		abductorAudioSource = gameObject.AddComponent<AudioSource> () as AudioSource;
		abductorAudioSource.loop = false;
		abductorAudioSource.clip = abductorNoise;

		flyingAudioSource = gameObject.GetComponent<AudioSource> () as AudioSource;
		flyingAudioSource.pitch = startPitch;
		flyingAudioSource.loop = true;
		flyingAudioSource.clip = flyingNoise;

		explosionAudioSource = gameObject.AddComponent<AudioSource> () as AudioSource;
		explosionAudioSource.clip = explosion;
		explosionAudioSource.loop = false;

		flyingAudioSource.volume = 1.0f * hoverNoiseMultiplier;
		abductorAudioSource.volume = 1.0f;
	}

	void Start() {
		flyingAudioSource.Play ();
	}

	public void SetAudioClip(AudioSource audioSource, AudioClip clip, bool looping) {
		audioSource.clip = clip;
		audioSource.loop = looping;
	}

	public void increasePitch () {
		if (flyingAudioSource.pitch < maxPitch) {
			flyingAudioSource.pitch += Time.deltaTime * 10f * pitchUpRate;
		}
	}

	public void decreasePitch () {
		if (flyingAudioSource.pitch > minPitch) {
			flyingAudioSource.pitch -= Time.deltaTime * 20f * pitchDownRate;
		}
	}

	public void Explode() {
		flyingAudioSource.Stop ();
		explosionAudioSource.Play ();
	}

	public void Abduct() {
		abductorAudioSource.Play ();
	}
}
