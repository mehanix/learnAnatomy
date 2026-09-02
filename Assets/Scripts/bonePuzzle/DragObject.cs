using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour {
	private static DragObject currentlyDragged = null;
	private Vector3 screenPoint;
	private Vector3 offset;
	private Rigidbody rb;
	private Camera cam;

	void Start () {
		rb = GetComponent<Rigidbody>();
		cam = Camera.main;
	}

	void Update () {
		if (cam == null) cam = Camera.main;
		if (cam == null) return;

		// Mouse button pressed: check if clicking on this bone
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				if (hit.transform == this.transform) {
					currentlyDragged = this;
					screenPoint = cam.WorldToScreenPoint(transform.position);
					offset = transform.position - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
					if (rb != null) {
						rb.WakeUp();
					}
					Debug.Log("Picked up bone: " + gameObject.name);
				}
			}
		}

		// Dragging
		if (currentlyDragged == this && Input.GetMouseButton(0)) {
			Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			Vector3 curPosition = cam.ScreenToWorldPoint(curScreenPoint) + offset;
			transform.position = curPosition;
			if (rb != null) {
				rb.position = curPosition;
				rb.WakeUp();
			}
			Physics.SyncTransforms();

			// Check proximity to matching socket
			CheckSocketSnap();
		}

		// Mouse released
		if (currentlyDragged == this && Input.GetMouseButtonUp(0)) {
			CheckSocketSnap();
			Debug.Log("Released bone: " + gameObject.name);
			currentlyDragged = null;
		}
	}

	void CheckSocketSnap()
	{
		Collider[] hits = Physics.OverlapSphere(transform.position, 1.2f);
		foreach (Collider hit in hits) {
			if (hit.gameObject != this.gameObject && hit.gameObject.name == this.gameObject.name) {
				MeshRenderer mr = hit.gameObject.GetComponent<MeshRenderer>();
				if (mr != null) mr.enabled = true;
				SphereCollider sc = hit.gameObject.GetComponent<SphereCollider>();
				if (sc != null) sc.enabled = false;
				currentlyDragged = null;
				Destroy(this.gameObject);
				break;
			}
		}
	}

	void OnMouseDown()
	{
		if (currentlyDragged == null) {
			if (cam == null) cam = Camera.main;
			if (cam == null) return;
			screenPoint = cam.WorldToScreenPoint(transform.position);
			offset = transform.position - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
			if (rb != null) {
				rb.WakeUp();
			}
			currentlyDragged = this;
		}
	}

	void OnMouseDrag()
	{
		if (currentlyDragged == this) {
			if (cam == null) cam = Camera.main;
			if (cam == null) return;
			Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			Vector3 curPosition = cam.ScreenToWorldPoint(curScreenPoint) + offset;
			transform.position = curPosition;
			if (rb != null) {
				rb.position = curPosition;
				rb.WakeUp();
			}
			Physics.SyncTransforms();
			CheckSocketSnap();
		}
	}

	void OnMouseUp()
	{
		if (currentlyDragged == this) {
			CheckSocketSnap();
			currentlyDragged = null;
		}
	}
}
