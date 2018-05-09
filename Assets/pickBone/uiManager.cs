using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiManager : MonoBehaviour {

	public pickBoneGameManager gm;
	public Text skipBtnText;

	void Start()
	{
		gm = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<pickBoneGameManager> ();
	}

	public void startGame()
	{
		gm.startGame ();
	}

	public void skipQuestion()
	{
		gm.shouldSwitchQuestion = true;
		pickBoneGameManager.resetWrongBones ();

		skipBtnText.text = "Sari";
	}

	public void backToMenu()
	{
		SceneManager.LoadScene ("menu");
	}
}
