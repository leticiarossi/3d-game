using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour {

	public int roomToLoad;

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			Application.LoadLevel (roomToLoad);
		}
	}
}
