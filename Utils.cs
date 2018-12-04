using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils {

	public static int RandomNumber(int max) {
		return (int)Mathf.Floor (Random.Range (0, max));
	}

	public static GameObject RandomObj(GameObject[] arr) {
		return arr[RandomNumber (arr.Length)];
	}

	public static Texture RandomTexture(Texture[] arr) {
		return arr [RandomNumber (arr.Length)];
	}

	public static Transform FindChildByTag(Transform tr, string tag) {
		Transform trans = null;
		foreach (Transform child in tr) {
			if (child.tag == tag) {
				trans = child;
			}
		}
		return trans;
	}

}
