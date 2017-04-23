using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBrokenController : MonoBehaviour {

	public bool hasItem;
	public GameObject item;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Fireball") {
			if (hasItem) {
				Instantiate (item, transform.position, transform.rotation);
			}
			Destroy (transform.gameObject);
		}
	}
}
