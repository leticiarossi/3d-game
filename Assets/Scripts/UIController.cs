using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Text countText;

	private GameStateManager gameManager;
	private int candleCount;
	private int totalCandles;
	private int lives;

	void Start () {
		gameManager = GameStateManager.Instance;
		totalCandles = gameManager.GetTotalCandlesNumber ();
		candleCount = gameManager.GetCandlesLitCounter ();
		lives = gameManager.GetLivesLeft ();
		setCountText ();
	}

	void Update () {
		candleCount = gameManager.GetCandlesLitCounter ();
		setCountText ();
		lives = gameManager.GetLivesLeft ();
	}

	void setCountText(){
		countText.text = candleCount.ToString () + "/" + totalCandles;
	}
}
