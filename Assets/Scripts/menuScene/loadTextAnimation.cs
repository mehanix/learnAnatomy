using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadTextAnimation : MonoBehaviour {

	float alpha;
	float sign=-1;
	CanvasRenderer cr;
	// Use this for initialization
	void Start () {
		alpha = 0;
		cr = GetComponent<CanvasRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (alpha < 0f)
			sign = 1;
		if (alpha > 1f)
			sign = -1;
		
		alpha = alpha + sign * 0.05f;
		cr.SetAlpha (alpha);
		Debug.Log (alpha.ToString ());

	}
}
