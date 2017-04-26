using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBroken : MonoBehaviour {

	public bool hasItem;
	public GameObject item;
	public Transform powerUpSpawn;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Fireball") {
			if (hasItem) {
				Instantiate (item, powerUpSpawn.position, powerUpSpawn.rotation);
			}
			Destroy (transform.gameObject);
		}
	}
}
