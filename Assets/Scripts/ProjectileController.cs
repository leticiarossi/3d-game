using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		Destroy (transform.gameObject);
	}
}
