using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 2f;

	public GameObject fireball;
	public Transform fireballSpawn;

	private Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody> ();
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Space)) {
			Fire ();
		}
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertixal = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertixal);
		transform.rotation = Quaternion.LookRotation(movement);

		movement = movement.normalized * speed * Time.deltaTime;

		rb.MovePosition (transform.position + movement);
	}

	void Fire() {
		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject)Instantiate (
			fireball,
			fireballSpawn.position,
			fireballSpawn.rotation);

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 2.0f);
	}
}
