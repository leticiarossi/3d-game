using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelNormal : MonoBehaviour {

	public GameObject brokenBarrel;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Fireball") {
			Destroy (transform.gameObject);
			Instantiate (brokenBarrel, transform.position, transform.rotation);
		}
	}

}
