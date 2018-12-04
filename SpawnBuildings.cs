using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuildings : MonoBehaviour {

	public GameObject[] bases;
	public GameObject[] middles;
	public GameObject[] roofs;
	public GameObject[] toppers;
	public GameObject[] signs;
	public GameObject[] officeBuildings;
	public Texture[] textures;

	private Vector3 oneEighty = new Vector3 (0f, 180f, 0f);

	public void SpawnOffices (Transform ground) {
		Transform buildingTransform = ground.Find ("BuildingPosition").transform;
		GameObject offices = Instantiate (Utils.RandomObj(officeBuildings), buildingTransform.position, Quaternion.identity);
		offices.transform.Rotate (oneEighty);
	}

	private GameObject instantiateChildGameObject(GameObject objToCreate, Transform transform) {
		return Instantiate(objToCreate, transform.position, Quaternion.identity) as GameObject;
	}

	public void SpawnApartments(Transform ground) {
		int height = Utils.RandomNumber (3);
		Transform buildingTransform = ground.Find ("BuildingPosition").transform;
		GameObject floor = null;
		GameObject roof = null;
		Texture texture = Utils.RandomTexture (textures);
		int hasRoofTopper = Utils.RandomNumber (2);

		//instantiate floors up to desired height

		for (int i = 0; i < height + 1; i++) {
			if (floor == null) {
				// if it's the first one, pick a door part or shop part
				floor = instantiateChildGameObject (Utils.RandomObj(bases), buildingTransform);
			} else {
				// if not, do the upper floors
				floor = instantiateChildGameObject (Utils.RandomObj(middles), floor.transform.Find ("Next"));
			}
			Renderer renderer = floor.GetComponent<Renderer> ();
			renderer.material.SetTexture ("_MainTex", texture);
			floor.transform.Rotate (oneEighty);
		}

		//put a roof on top
		roof = instantiateChildGameObject(Utils.RandomObj(roofs), floor.transform.Find("Next"));
		roof.transform.Rotate (oneEighty);

		//maybe put a billboard or satellite dish or something

		if (hasRoofTopper > 0) {
			GameObject roofTopper = Instantiate(Utils.RandomObj(toppers), roof.transform.Find("Topper").transform.position, Quaternion.identity) as GameObject;
			if (roofTopper.tag == "Billboard") {
				GameObject sign = instantiateChildGameObject(Utils.RandomObj(signs), roofTopper.transform);
				sign.transform.Rotate (oneEighty);
			}
			roofTopper.transform.Rotate (oneEighty);
		}
	}
}

