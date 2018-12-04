using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		Destroy(other.gameObject);
	}

	void OnColliderEnter(Collision other) {
		Destroy (other.gameObject);
	}
}
