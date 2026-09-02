using UnityEngine;
using System.Collections;

public class ObjectRotator : MonoBehaviour 
{
	public int speed = 30;

	void Update () {

		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			transform.Rotate(Vector3.up * speed * Time.deltaTime);

		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			transform.Rotate(-Vector3.up * speed * Time.deltaTime);

		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			transform.Rotate(Vector3.right * speed * Time.deltaTime);

		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			transform.Rotate(-Vector3.right * speed * Time.deltaTime);

	}
}