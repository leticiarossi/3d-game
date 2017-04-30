using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Text countText;
	private int totalCandles;

	private GameStateManager gameManager;
	private int candleCount;
	private int livesLeft;

	public RawImage life1;
	public RawImage life2;
	public RawImage life3;

	void Start () {
		gameManager = GameStateManager.Instance;
		totalCandles = gameManager.GetTotalCandlesNumber ();
		candleCount = gameManager.GetCandlesLitCounter ();
		livesLeft = gameManager.GetLivesLeft ();
		setCountText ();
		life1.enabled = true;
		life2.enabled = true;
		life3.enabled = true;
	}

	void Update () {
		candleCount = gameManager.GetCandlesLitCounter ();
		setCountText ();
		livesLeft = gameManager.GetLivesLeft ();
		UpdateLives ();
		if (Input.GetKeyDown (KeyCode.Escape) && (Time.timeScale == 1)) {
			MenuManager.EnablePause ();
		} else if (Input.GetKeyDown (KeyCode.Escape) && (Time.timeScale == 0)){
				MenuManager.DisablePause ();
		}
	}

	void setCountText(){
		countText.text = candleCount.ToString () + "/ " + totalCandles.ToString();
	}

	void UpdateLives(){
		if (livesLeft < 3) {
			life3.enabled = false;
		}
		if (livesLeft < 2) {
			life2.enabled = false;
		}
		if (livesLeft < 1) {
			life1.enabled = false;
		}
	}
}
