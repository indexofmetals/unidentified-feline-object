using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

	private int score;
	private int highScore;
	public Text scoreText;
	public Text highScoreText;

	void Awake() {
		score = 0;
		highScore = PrefsManager.GetHighScore ();
		scoreText = GetScoreTextObj ();
		highScoreText = GetHighScoreTextObj ();
		SetText ();
	}

	public Text GetScoreTextObj() {
		return GameObject.Find ("ScoreText").GetComponent<Text>();
	}

	public Text GetHighScoreTextObj() {
		return GameObject.Find ("HighScoreText").GetComponent<Text>();
	}

	public void SetText() {
		scoreText.text = "Score: " + score.ToString ();
		highScoreText.text = "High Score: " + highScore.ToString ();
	}

	public void Increment() {
		score += 325;
		if (score > highScore) {
			highScore = score;
			PrefsManager.SetHighScore (highScore);
		}
		SetText ();
	}
}
