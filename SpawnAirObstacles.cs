using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAirObstacles : MonoBehaviour {

	public GameObject blimp;
	public GameObject hotAirBalloon;

	public void Spawn(Transform airTransform) {
		int flip = Utils.RandomNumber (2);
		if (flip == 0) {
			Instantiate (blimp, airTransform.position, Quaternion.identity);
		} else if (flip == 1) {
			Instantiate (hotAirBalloon, airTransform.position, Quaternion.identity);
		}
	}
}
