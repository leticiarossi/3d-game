using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform target;

	public float distance = 4;
	public float minVerticalAngle = -80;
	public float maxVerticalAngle = 80;

	public float verticalSpeed = 150;
	public float horizontalSpeed = 300;

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
		offset *= distance;

		transform.position = target.position + offset;
		transform.rotation = Quaternion.LookRotation(target.position - transform.position, new Vector3(0,1,0));
	}
}
