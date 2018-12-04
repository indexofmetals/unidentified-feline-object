using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPeople : MonoBehaviour {

	public GameObject Person;

	public void Spawn (Transform ground) {
		Transform peopleTransform = ground.transform.Find ("PeoplePosition");
		if (peopleTransform != null) {
			foreach (Transform child in peopleTransform) {
				Instantiate (Person, child.position, Quaternion.identity);
			}
		}
	}

}
