using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script to handle changing of scenes and rooms.
 */

public class ExitDoor : MonoBehaviour {

	public int roomToLoad;
	public string spawnName;
	public Transform spawnPoint;

	private GameStateManager gameManager;

	void Awake () {
		gameManager = GameStateManager.Instance;
		if (spawnName == gameManager.getLastSpawnName ()) {
			gameManager.setCurrentSpawnPoint (spawnPoint);
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			gameManager.setLastSpawnName (spawnName);
			Application.LoadLevel (roomToLoad);
		}
	}
}
