using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeButtons : MonoBehaviour {

	private LevelManager levelManager;

	public string SettingsScene = "Settings";
	public string GameScene = "Game";

	void Awake() {
		levelManager = FindObjectOfType<LevelManager> ();
	}

	public void LoadSettings() {
		levelManager.Load (SettingsScene);
	}

	public void LoadGame() {
		levelManager.Load (GameScene);
	}
}
