using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlFocalPoint : MonoBehaviour {

	Vector3 poz = new Vector3 ();
	 float speed = 35f;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	
	// Update is called once per frame
	void FixedUpdate () {
		/*
		poz = transform.position;
		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W))
			poz.y += ratio;
		if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S))
			poz.y -= ratio;
		if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.D))
			poz.x += ratio;
		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.A))
			poz.x -= ratio;
		transform.position = poz;*/

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal,moveVertical, 0.0f);

		rb.AddForce (movement * speed);
		if (Input.anyKeyDown == false)
			rb.velocity = Vector3.zero;
	}
}
