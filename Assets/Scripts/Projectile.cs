using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script to handle the collision of fireballs and waterballs with other objects. 
 */

public class Projectile : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (tag == "Fireball" && other.tag == "Player") {
			return;
		}
		Destroy (transform.gameObject);
	}
}
