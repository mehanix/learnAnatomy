using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boneSpread : MonoBehaviour {


	void Start() {
	
		setRandomPosition ();
	
	}

	void setRandomPosition()
	{
		Vector3 screenPoint = new Vector3(Random.Range(0,Screen.width-10),Random.Range(0,Screen.height-30),(transform.position.z - Camera.main.transform.position.z) );
		Vector3 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);
		transform.position = new Vector3 (worldPoint.x, worldPoint.y, transform.position.z);

		Debug.Log (Screen.width);
	}
}
