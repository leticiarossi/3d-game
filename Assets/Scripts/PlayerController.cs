using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 2f;

	private Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertixal = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertixal);

		movement = movement.normalized * speed * Time.deltaTime;

		rb.MovePosition (transform.position + movement);
	}
}
