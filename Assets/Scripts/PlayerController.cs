﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 2f;

	public GameObject fireball;
	public Transform fireballSpawn;

	private Rigidbody rb;
	private int playerSize = 4; // Player has 4 different sizes (can shoot up to 3 times in a row)
	private float[] sizes = {0.4f, 0.6f, 0.8f, 1.0f};
	private bool isOnCourotine = false;

	void Start() {
		rb = GetComponent<Rigidbody> ();
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Space)) {
			Fire ();
		}
		if (playerSize < 4 && !isOnCourotine) {
			isOnCourotine = true;
			StartCoroutine (IncreaseSize ());
		}
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		// Make player face direction it is moving to
		if (movement != Vector3.zero) {
			transform.rotation = Quaternion.LookRotation (movement);
		}

		movement = movement.normalized * speed * Time.deltaTime;

		rb.MovePosition (transform.position + movement);
	}

	void Fire() {
		if (playerSize > 1) {
			// Create the fireball 
			GameObject shot = Instantiate (fireball, fireballSpawn.position, fireballSpawn.rotation);

			// Add velocity to it
			shot.GetComponent<Rigidbody> ().velocity = shot.transform.forward * 6;

			// Make player smaller
			DecreaseSize();

			// Fireball vanishes after 2 seconds
			Destroy (shot, 2.0f);
		}
	}

	void DecreaseSize () {
		playerSize--;
		float scale = sizes [playerSize - 1];
		transform.localScale = new Vector3 (scale, scale, scale);
	}

	IEnumerator IncreaseSize(){
		if (isOnCourotine) {
			
			while (transform.localScale.x < 1f) {
				transform.localScale += new Vector3 (1, 1, 1) * Time.deltaTime * 0.1f;

				if (transform.localScale.x > sizes [3]) {
					// Don't let player go over max size
					transform.localScale = new Vector3 (sizes [3], sizes [3], sizes [3]);
					playerSize = 4;
				} else if (transform.localScale.x >= sizes [2]) {
					playerSize = 3;
				} else if (transform.localScale.x >= sizes [1]) {
					playerSize = 2;
				} else {
					playerSize = 1;
				}
				yield return null;
			}
			playerSize = 4;
			isOnCourotine = false;
		}
	}
}
