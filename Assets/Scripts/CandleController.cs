using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleController : MonoBehaviour {

	public GameObject candle;
	public GameObject litCandle;

	// Use this for initialization
	void Start () {
		candle.SetActive (true);
	}

	void OnTriggerEnter (Collider Other){
		if (Other.tag == "Fireball") {
			LightCandle ();
		}
	}

	void LightCandle(){
		Vector3 candlePosition = candle.transform.position;
		Quaternion candleRotation = candle.transform.rotation;
		Destroy (candle);
		Instantiate (litCandle, candlePosition, candleRotation);
	}
}
