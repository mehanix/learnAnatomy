using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
	public GameObject firstGameObject, secondGameObject;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other)
	{
		if (gameObject.GetComponent<Rigidbody>() != null) {
			Debug.Log(gameObject.name + " collided with " + other.gameObject.name);
			if (gameObject.name == other.gameObject.name) {
				MeshRenderer mr = other.gameObject.GetComponent<MeshRenderer>();
				if (mr != null)
					mr.enabled = true;

				SphereCollider sc = other.gameObject.GetComponent<SphereCollider>();
				if (sc != null)
					sc.enabled = false;

				Destroy(this.gameObject);
			}
		}
	}
}
