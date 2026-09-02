using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFov : MonoBehaviour {

	public float minFov = 15f;
	public float maxFov = 90f;
	public float sensitivity = 10f;
	private Camera cam;

	void Awake() {
		cam = GetComponent<Camera>();
		if (cam == null) cam = Camera.main;
		if (cam != null) {
			cam.clearFlags = CameraClearFlags.SolidColor;
			cam.backgroundColor = new Color(0.1411765f, 0.1411765f, 0.1411765f, 1.0f);
		}
	}

	void Update () {
		if (cam == null) cam = Camera.main;
		if (cam == null) return;

		float fov = cam.fieldOfView;
		fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
		fov = Mathf.Clamp(fov, minFov, maxFov);
		cam.fieldOfView = fov;
	}
}
