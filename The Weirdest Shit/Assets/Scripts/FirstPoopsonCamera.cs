using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPoopsonCamera : MonoBehaviour
{

	public Transform cameraAnchor;
	float xRot;
	float yRot;
	public float sensitivity = 1;

	[Range(0,90)]
	public float maxAngle = 85;

	// Use this for initialization
	void Start ()
	{
		//Cursor.lockState = CursorLockMode.Locked;
		//Cursor.visible = true;

		if (cameraAnchor==null)
		{
			cameraAnchor = GetComponentInChildren<Transform>();
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		xRot += Input.GetAxis("Mouse X")*sensitivity;
		yRot += Input.GetAxis("Mouse Y")*sensitivity;
		yRot = Mathf.Clamp(yRot, -maxAngle, maxAngle);
		cameraAnchor.localRotation = Quaternion.AngleAxis(-yRot,Vector3.right);
		cameraAnchor.localRotation = Quaternion.AngleAxis(xRot,Vector3.up) * cameraAnchor.localRotation;
	}
}
