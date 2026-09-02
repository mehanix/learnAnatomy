using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boneSpread : MonoBehaviour {

	private static int boneIndex = 0;

	void Awake() {
		// Detach from scaled parent so Rigidbody is an independent root object in world space
		transform.SetParent(null, true);
	}

	void Start() {
		setRandomPosition();
	}

	public void setRandomPosition()
	{
		Camera cam = Camera.main;
		if (cam == null) cam = FindFirstObjectByType<Camera>();
		if (cam == null) {
			Debug.LogError("No camera found for boneSpread on " + gameObject.name);
			return;
		}

		int idx = boneIndex++;
		bool isLeft = (idx % 2 == 0);

		// Clean, organized layout on left and right columns
		float marginX = isLeft ? Random.Range(0.04f, 0.26f) : Random.Range(0.74f, 0.96f);
		float marginY = Random.Range(0.08f, 0.92f);

		Vector3 screenPoint = new Vector3(Screen.width * marginX, Screen.height * marginY, 19.7f);
		Vector3 worldPoint = cam.ScreenToWorldPoint(screenPoint);
		Vector3 targetPos = new Vector3(worldPoint.x, worldPoint.y, 11.22f);

		transform.position = targetPos;

		Rigidbody rb = GetComponent<Rigidbody>();
		if (rb != null) {
			rb.position = targetPos;
			rb.WakeUp();
		}
		Physics.SyncTransforms();

		Debug.Log("boneSpread positioned " + gameObject.name + " at " + targetPos);
	}
}
