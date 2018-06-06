using UnityEngine;
using System.Collections;

public class ObjectRotator : MonoBehaviour 
{

	public int speed = 30;

	void Update () {

		if (Input.GetKey(KeyCode.D))
			transform.Rotate(Vector3.up * speed * Time.deltaTime);

		if (Input.GetKey(KeyCode.A))
			transform.Rotate(-Vector3.up * speed * Time.deltaTime);

		if (Input.GetKey(KeyCode.S))
			transform.Rotate(Vector3.right * speed * Time.deltaTime);

		if (Input.GetKey(KeyCode.W))
			transform.Rotate(-Vector3.right * speed * Time.deltaTime);
		

	}

}