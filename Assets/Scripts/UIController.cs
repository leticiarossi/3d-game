using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Text countText;

	private GameStateManager gameManager;
	private int candleCount;
	private int totalCandles;

	void Start () {
		gameManager = GameStateManager.Instance;
		totalCandles = gameManager.GetTotalCandlesNumber ();
		candleCount = gameManager.GetCandlesLitCounter ();
		setCountText ();
	}

	void Update () {
		candleCount = gameManager.GetCandlesLitCounter ();
		setCountText ();
	}

	void setCountText(){
		countText.text = candleCount.ToString () + "/" + totalCandles;
	}
}
