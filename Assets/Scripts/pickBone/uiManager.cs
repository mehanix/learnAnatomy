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
		pickBoneGameManager.correctBoneClicked = false;
		skipBtnText.text = "Sari";
	}

	public void backToMenu()
	{
		SceneManager.LoadScene ("menu");
	}

	public void showCorrectBone()
	{
		Debug.Log (pickBoneGameManager.currentBoneId.ToString ());
		pickBoneGameManager.bonesArray [pickBoneGameManager.currentBoneId].GetComponent<MeshRenderer> ().material.color = Color.yellow;
		pickBoneGameManager.bonesArray [pickBoneGameManager.currentBoneId].GetComponent<MeshCollider> ().enabled = false;

		pickBoneGameManager.bonesArray [pickBoneGameManager.currentBoneId].GetComponent<onBoneClick>().m_OriginalColor = Color.yellow;
	
	}
}
