using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Text countText;
	private int totalCandles;

	private GameStateManager gameManager;
	private int candleCount;

	void Start () {
		gameManager = GameStateManager.Instance;
		totalCandles = gameManager.GetTotalCandlesNumber ();
		candleCount = gameManager.GetCandlesLitCounter ();
		setCountText ();
	}

	void Update () {
		candleCount = gameManager.GetCandlesLitCounter ();
		setCountText ();
		if (Input.GetKeyDown (KeyCode.Escape) && (Time.timeScale == 1)) {
			MenuManager.EnablePause ();
		} else if (Input.GetKeyDown (KeyCode.Escape) && (Time.timeScale == 0)){
				MenuManager.DisablePause ();
		}
	}

	void setCountText(){
		countText.text = candleCount.ToString () + "/ " + totalCandles.ToString();
	}
}
