using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {
	public GameObject instructionsWindow;

	void Start () {
		
	}
	
	void Update () {
		if (instructionsWindow != null && instructionsWindow.activeSelf) {
			if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Escape)) {
				startGame();
			}
		}
	}

	public void startGame()
	{
		if (instructionsWindow != null) {
			instructionsWindow.SetActive(false);
		}
	}

	public void backtomenu()
	{
		SceneManager.LoadScene("menu");
	}
}
