using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void Load(string SceneName) {
		SceneManager.LoadScene (SceneName, LoadSceneMode.Single);
	}

	public void Awake() {
		DontDestroyOnLoad (gameObject);
	}
}
