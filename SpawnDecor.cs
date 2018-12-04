using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDecor : MonoBehaviour {

	public GameObject[] trashObjects;
	public GameObject[] trees;
	public GameObject parkBench;
	public GameObject picnicTable;

	public void SpawnPark(Transform ground) {
		SpawnTrees (ground);
		SpawnBenches (ground);
	}

	public void SpawnAlley(Transform alley) {
		Transform trashPositions = alley.Find ("TrashPosition");
		foreach(Transform child in trashPositions) {
			if(Utils.RandomNumber(2) == 0) {
				Instantiate (Utils.RandomObj (trashObjects), child.position, Quaternion.identity);	
			}
		}
	}

	public void SpawnTrees(Transform ground) {
		foreach (Transform child in ground.transform) {
			if (child.name == "TreePosition") {
				Instantiate(Utils.RandomObj(trees), child.position, Quaternion.identity);
			}
		}
	}

	public void SpawnBenches(Transform ground) {
		foreach (Transform child in ground.transform) {
			if (child.name == "BenchPosition") {
				Instantiate (parkBench, child.position, Quaternion.identity);
			}
			if (child.name == "PicnicTablePosition") {
				Instantiate (picnicTable, child.position, Quaternion.identity);
			}
		}
	}
}
