using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script to continuously rotate an object around its Y-axis.
 */

public class ItemRotator : MonoBehaviour {
	
	void Update () {
		transform.Rotate (0, 60 * Time.deltaTime, 0);
	}
}
