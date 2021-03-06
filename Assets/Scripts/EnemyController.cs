﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script to handle things related to the enemy (the water drop), like shooting waterballs at the player,
 * being hurt, changes of its color, dying, etc.
 */

public class EnemyController : MonoBehaviour {

	public float shootInterval = 4f;
	public float maxAttackDistance = 10f;
	public float smoothTime = 6f;
	public int maxHits = 3;

	public GameObject waterball;
	public GameObject mesh;
	public Transform waterballSpawn;
	public Transform target;

	private Vector3 smoothVelocity = Vector3.zero;
	private float shootTime = 0;
	private int hitCount = 0; // How many times enemy is hit 
	private Renderer rndr;
	// Colors indicate how hot waterdrop is
	private Color32[] colors = {new Color32(45, 139, 191, 255),
								new Color32(117, 98, 128, 255),
								new Color32(176, 72, 88, 255)};

	void Start (){
		rndr = mesh.GetComponent<Renderer> ();
	}

	void Update () {
		float distance = Vector3.Distance(target.position, transform.position);
		if (distance < maxAttackDistance) {
			LookAtTarget ();
			if ((Time.time - shootTime) > shootInterval) {
				Fire ();
			}
		}
	}

	void LookAtTarget() {
		Vector3 direction = target.position - transform.position;
		direction.y = 0;
		transform.rotation = Quaternion.LookRotation (direction);
	}

	void Fire() {
		shootTime = Time.time;
		// Create waterball
		GameObject shot = Instantiate (waterball, waterballSpawn.position, waterballSpawn.rotation);

		// Add velocity to it
		shot.GetComponent<Rigidbody> ().velocity = shot.transform.forward * 6;

		// Waterball vanishes after 2 seconds
		Destroy (shot, 2.0f);
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Fireball") {
			Hit ();
		}
	}

	void Hit() {
		hitCount++;
		if (hitCount < 3) {
			rndr.material.SetColor ("_EmissionColor", colors[hitCount]);
		} else {
			// Enemy dies
			Destroy (transform.gameObject);
		}
	}
}
