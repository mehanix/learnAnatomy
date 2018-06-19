using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {
	public GameObject instructionsWindow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void startGame()
	{
		instructionsWindow.SetActive (false);
	}

	public void backtomenu()
	{
		SceneManager.LoadScene ("menu");
	}
}
