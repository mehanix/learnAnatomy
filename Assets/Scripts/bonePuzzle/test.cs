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
		//if (gameObject.GetComponent<Rigidbody> () != null) {
			//Debug.Log (gameObject.name + " " + other.gameObject.name);
			if (gameObject.name == other.gameObject.name) {
				other.gameObject.GetComponent<MeshRenderer> ().enabled = true;
				other.gameObject.transform.localScale = new Vector3 (1f, 1f, 1f);
			other.gameObject.GetComponent<MeshCollider> ().enabled = false;
			gameObject.GetComponent<test> ().enabled = false;

				Destroy (this.gameObject);
		
		//}
	
		}
	}
}
