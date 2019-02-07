using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour {

	public GameObject cameraFocusPoint;
	public Text boneName;
	public Text description;
	public GameObject helpWindow;
	public void backToMenu() {
		SceneManager.LoadScene ("menu");
	}

	public void backToSkeleton() {

		Camera.main.cullingMask = Camera.main.cullingMask | (1 << 9); //reafiseaza layerul Bones

		//pt femur si torace
		if (Zoom.selectedBone.transform.childCount > 0)
			Zoom.selectedBone.gameObject.transform.GetChild (0).gameObject.layer = 9;
		//reset layer os selectat anterior
		Zoom.selectedBone.layer = 9;
		Zoom.selectedBone = null;
	/*	foreach (GameObject go in Zoom.blocks) {
			go.SetActive (true);
		} */
			//Debug.Log (go.name);
			cameraFocusPoint.transform.position = new Vector3 (0.02f, -0.14f, 0.53320f);
			boneName.text = "Numele Osului";
			description.text = "Informatiile despre osul selectat vor aparea aici :)";
			gameObject.SetActive (false);
		


	}

	public void showHelpWindow ()
	{
		helpWindow.SetActive (true);
	}

	public void hideHelpWindow ()
	{
		helpWindow.SetActive (false);
	}

}
