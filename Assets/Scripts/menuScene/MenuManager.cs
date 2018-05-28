using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void switchToWorld(string sceneName) {
		SceneManager.LoadScene (sceneName);
	}

	public void exitGame() {
	
		Application.Quit ();
	}

	public void Start() {
	
	
	}
}
