using UnityEngine;
using System.Collections;

/*
 * Script to manage and control the camera.
 */

public class CameraController : MonoBehaviour {

	public Transform player;

	public float maxDistance = 4;
	public float minDistance = .5f;

	public float minVerticalAngle = -80;
	public float maxVerticalAngle = 80;

	public float verticalSpeed = 150;
	public float horizontalSpeed = 300;

	private float curDistance;

	private float angleX;
	private float angleY;

	void Start () {
		angleX = -45;
		angleY = 0;
	}

	void Update () {
		angleX += Input.GetAxis("Mouse Y") * Time.deltaTime * verticalSpeed;
		angleY += Input.GetAxis("Mouse X") * Time.deltaTime * verticalSpeed;

		angleX = Mathf.Clamp(angleX, minVerticalAngle, maxVerticalAngle);
		angleY %= 360;

		Quaternion xRotation = Quaternion.AngleAxis(angleX, new Vector3(1,0,0));
		Quaternion yRotation = Quaternion.AngleAxis(angleY, new Vector3(0,1,0));
		Vector3 offset = new Vector3(0,0,1);
		offset = xRotation * offset;
		offset = yRotation * offset;

		RaycastHit hit;

		// If there is an object between the player and the camera 
		if (Physics.Raycast (player.position, transform.position, out hit, maxDistance)) { 
			//&& hit.transform.tag == "Wall") {
			// Place the camera in front of the obstacle but outside of the player
			curDistance = Mathf.Clamp (hit.distance, minDistance, maxDistance);
		} else { 
			// Reset the camera to its normal distance
			curDistance = maxDistance;

		}

		offset *= curDistance;

		transform.position = player.position + offset;
		transform.rotation = Quaternion.LookRotation(player.position - transform.position, new Vector3(0,1,0));
	}
}
