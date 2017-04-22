using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float speed = 1f;
	public float shootInterval = 1f;
	public float attackRadius = 10f;

	public GameObject waterball;
	public Transform waterballSpawn;
	public Transform target;

	private Rigidbody rb;
	private int enemySize = 4; 
	private float[] sizes = {0.4f, 0.6f, 0.8f, 1.0f};
	private float shootTime = 0;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void Update () {
		LookAtTarget ();
		float distance = Vector3.Distance(target.position, transform.position);
		if (distance <= attackRadius && (Time.time - shootTime) > shootInterval) {
			Fire ();
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
			Destroy (other.gameObject);
		}
	}
}
