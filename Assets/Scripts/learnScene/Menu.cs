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
		
		foreach (GameObject go in Zoom.blocks) {
			go.SetActive (true);
		}
			//Debug.Log (go.name);
			cameraFocusPoint.transform.position = new Vector3 (0.02f, -0.14f, 0.53320f);
			boneName.text = "Numele Osului";
			description.text = "Informatiile despre osul selectat vor aparea aici :)";
		


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
