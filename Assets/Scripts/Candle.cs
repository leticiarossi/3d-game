using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour {

	public GameObject fire;
	bool isLit = false;

	void Start () {
		fire.SetActive (false);
	}

	void OnTriggerEnter (Collider other){
		if (!isLit && other.tag == "Fireball") {
			fire.SetActive (true);
			isLit = true;
		} else if (isLit && other.tag == "Waterball") {
			fire.SetActive (false);
			isLit = false;
		}
	}
}
