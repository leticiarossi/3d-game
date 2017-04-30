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
	public AudioClip doorClose;
	private AudioSource source;
	private GameStateManager gameManager;

	void Awake () {
		source = GetComponent<AudioSource>();
		gameManager = GameStateManager.Instance;
		if (spawnName == gameManager.GetLastSpawnName ()) {
			gameManager.SetCurrentSpawnPoint (spawnPoint);
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			other.attachedRigidbody.constraints = RigidbodyConstraints.FreezeAll;
			gameManager.SetLastSpawnName (spawnName);
			source.clip = doorClose;
			source.volume = 1f;
			source.pitch = 1f;
			source.PlayOneShot (doorClose);
			StartCoroutine (delayLevelLoad ());
		}
	}

	IEnumerator delayLevelLoad(){
		
		yield return new WaitForSeconds (1f);
		Application.LoadLevel (roomToLoad);
	}
}
