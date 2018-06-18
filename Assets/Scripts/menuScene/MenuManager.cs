using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public GameObject mainMenu, learnMenu, testMenu,loadingText;

	public void switchToWorld(string sceneName) {
		showLoadingText ();
		SceneManager.LoadScene (sceneName);

	}

	public void exitGame() {
	
		Application.Quit ();
	}

	public void learnBtnClick() {
	
		mainMenu.SetActive (false);
		learnMenu.SetActive (true);
		
	}

	public void backToMainMenu()
	{
		mainMenu.SetActive (true);
		learnMenu.SetActive (false);
		testMenu.SetActive (false);
	}

	public void testBtnClick() 
	{
		testMenu.SetActive (true);
		mainMenu.SetActive (false);
	}

	void showLoadingText ()
	{
		loadingText.SetActive (true);
	}
}
