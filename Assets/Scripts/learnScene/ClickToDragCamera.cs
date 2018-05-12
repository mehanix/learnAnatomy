using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToDragCamera : MonoBehaviour {

	public float speed= 20f;
	const int orthographicSizeMin = 1;
	const int orthographicSizeMax = 6;
	public GameManager gm;
	public float zoomSpeed;
	public float fovMin;
	public float fovMax;

	void Update () {

		speed = calculateSpeed (Camera.main.fieldOfView);
		Vector3 pos = transform.position;
		if (Input.GetMouseButton(1))
		{
			pos.x -= Input.GetAxis("Mouse X") * speed* Time.deltaTime;
			pos.y -= Input.GetAxis("Mouse Y") * speed* Time.deltaTime;
		}

		transform.position = pos;



		if (Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			Camera.main.fieldOfView += zoomSpeed;
		}
		if (Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			Camera.main.fieldOfView -= zoomSpeed;
		}
		Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, fovMin, fovMax);

	}﻿
		

	float calculateSpeed(float x)
	{

		return 2f + (x - 8f) * 0.19f;
	}
}
