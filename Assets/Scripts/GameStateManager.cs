using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script to manage and maintain the state of the game.
 */

public class GameStateManager : MonoBehaviour {

	private static GameStateManager instance;

	private string lastSpawnName;
	private Transform currentSpawnPoint;
	private int totalCandles;
	private int candlesLitCounter;
	private Dictionary<int,bool> candlesList;

	// Create an instance of GameStateManager as a GameObject if an instance does not exist
	public static GameStateManager Instance {
		get {
			if(instance == null) {
				instance = new GameObject ("GameStateManager").AddComponent<GameStateManager> ();
			}
			return instance;
		}
	}	

	// Set the instance to null when the application quits
	public void OnApplicationQuit () {
		instance = null;
	}

	// Create new game state
	public void StartState () {
		lastSpawnName = "";
		currentSpawnPoint = null;
		candlesLitCounter = 0;
		candlesList = new Dictionary<int, bool> ();
	}

	// Setter methods //

	public void setLastSpawnName (string spawn) {
		lastSpawnName = spawn;
	}

	public void setCurrentSpawnPoint (Transform spawn) {
		currentSpawnPoint = spawn;
	}

	public void IncreaseCandlesLit () {
		candlesLitCounter++;
	}

	public void SetCandleStatus (int key, bool status) {
		candlesList [key] = status;
	}

	// Getter methods //

	public string getLastSpawnName () {
		return lastSpawnName;
	}

	public Transform getCurrentSpawnPoint () {
		return currentSpawnPoint;
	}

	public int GetCandlesLitCounter () {
		return candlesLitCounter;
	}

	public bool getCandleStatus (int key) {
		if (!candlesList.ContainsKey (key)) { // Method is being called for the first time
			candlesList [key] = false;
		}
		return candlesList [key];
	}
}
