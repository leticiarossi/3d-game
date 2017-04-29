using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (tag == "Fireball" && other.tag == "Player") {
			Debug.Log ("oi");
			return;
		}
		Destroy (transform.gameObject);
	}
}
