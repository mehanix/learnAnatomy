using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSetup : MonoBehaviour {

	public void loadScene (string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}


}
