using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script to handle barrel being shot by the player for the first time.
 */

public class BarrelNormal : MonoBehaviour {

	public GameObject brokenBarrel;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Fireball") {
			Destroy (transform.gameObject);
			Instantiate (brokenBarrel, transform.position, transform.rotation);
		}
	}

}
