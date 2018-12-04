using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {

	public GameObject player;

	void LateUpdate () {
		transform.position = new Vector3 (player.transform.position.x + 1f, transform.position.y, transform.position.z);
	}
}
