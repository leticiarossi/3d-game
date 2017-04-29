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
		if (spawnName == gameManager.GetLastSpawnName ()) {
			gameManager.SetCurrentSpawnPoint (spawnPoint);
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			gameManager.SetLastSpawnName (spawnName);
			Application.LoadLevel (roomToLoad);
		}
	}
}
