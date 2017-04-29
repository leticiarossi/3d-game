using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script to handle candles being lit or not.
 */

public class Candle : MonoBehaviour {

	public GameObject fire;

	private GameStateManager gameManager;
	private bool isLit;
	private int candleListKey;

	void Start () {
		gameManager = GameStateManager.Instance;
		candleListKey = (Application.loadedLevel * 100) + transform.GetSiblingIndex ();
		isLit = gameManager.getCandleStatus (candleListKey);
		if (!isLit) {
			fire.SetActive (false);
		}
	}

	void OnTriggerEnter (Collider other){
		if (!isLit && other.tag == "Fireball") {
			fire.SetActive (true);
			isLit = true;
			gameManager.UpdateCandlesLit (1);
			gameManager.SetCandleStatus (candleListKey, isLit);
		} else if (isLit && other.tag == "Waterball") {
			fire.SetActive (false);
			isLit = false;
			gameManager.UpdateCandlesLit (-1);
			gameManager.SetCandleStatus (candleListKey, isLit);
		}
	}
}
