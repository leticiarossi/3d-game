using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

/*
 * Script to handle things related to the player, like movement, shooting fireballs, changes of its size,
 * using powerups, being hit/hurt, etc.
 */

public class PlayerController : MonoBehaviour {

	public float speed = 2f;

	public GameObject fireball;
	public GameObject mesh;
	public Transform fireballSpawn;
	public Transform reSpawnPoint;

	private Rigidbody rb;
	private Renderer rndr;
	private GameStateManager gameManager;

	private int lives;
	private int playerSize = 4; // Player has 4 different sizes (can shoot up to 3 times in a row)
	private float[] sizes = {0.4f, 0.6f, 0.8f, 1.0f};
	private bool isOnCourotine = false;
	private float shootTime = 0;
	private float shootInterval = 0.2f;
	private float puddleHurtTime = 0;
	private float puddleHurtInterval = 2f;
	private Color32 normalColor = new Color32(214, 155, 16, 255);
	private Color32 powerUpColor = new Color32(214, 16, 16, 255);

	private bool hasPowerUp = false;

	void Start() {
		rb = GetComponent<Rigidbody> ();
		rndr = mesh.GetComponent<Renderer> ();
		gameManager = GameStateManager.Instance;
		Transform spawnPosition = gameManager.getCurrentSpawnPoint ();
		if (spawnPosition != null) {
			transform.position = spawnPosition.position;
		}
		lives = gameManager.getLivesLeft ();
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Space) && (Time.time - shootTime) > shootInterval) {
			shootTime = Time.time;
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

		// Make player move forward in direction of camera
		movement = Camera.main.transform.TransformDirection(movement);
		movement.y = 0.0f;

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
			shot.GetComponent<Rigidbody> ().velocity = shot.transform.forward * 7;

			// Make player smaller
			if (!hasPowerUp) {
				DecreaseSize ();
			}

			// Fireball vanishes after 2 seconds
			Destroy (shot, 2.0f);
		}
	}

	void DecreaseSize () {
		playerSize--;
		float scale = sizes [playerSize - 1];
		transform.localScale = new Vector3 (scale, scale, scale);
	}

	void Hurt () {
		if (playerSize == 1) {
			if (lives < 1) { // Game over
				Destroy (transform.gameObject);
			} else {
				// Player loses 1 life
				transform.position = reSpawnPoint.position;
				transform.rotation = reSpawnPoint.rotation;
				lives--;
				gameManager.setLivesLeft (lives);
			}
		} else {
			DecreaseSize ();
		}
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

	IEnumerator PowerUp() {
		Color32 color;
		for (int i = 0; i < 200; i++) {
			hasPowerUp = true;
			if (i < 150) {
				color = Color32.Lerp (normalColor, powerUpColor, Mathf.PingPong (Time.time, 0.5f));
			} else {
				color = Color32.Lerp (normalColor, powerUpColor, Mathf.PingPong (Time.time, 0.3f));
			}
			rndr.material.SetColor ("_EmissionColor", color);
			yield return null;
		}
		hasPowerUp = false;
		rndr.material.SetColor ("_EmissionColor", normalColor);
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Waterball" && !hasPowerUp) {
			Hurt ();
		} else if (other.tag == "PowerUp") {
			Destroy (other.gameObject);
			StartCoroutine (PowerUp ());
		} else if (other.tag == "Water" && !hasPowerUp) {
			if ((Time.time - puddleHurtTime) > puddleHurtInterval) {
				puddleHurtTime = Time.time;
				Hurt ();
			}
		}
	}

	void OnTriggerStay (Collider other) {
		if (other.tag == "Water" && !hasPowerUp) {
			if ((Time.time - puddleHurtTime) > puddleHurtInterval) {
				puddleHurtTime = Time.time;
				Hurt ();
			}
		}
	}
}
