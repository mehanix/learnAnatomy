using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickBoneGameManager : MonoBehaviour {

	bool[] avaliableQuestions = new bool[150];
	public static GameObject[] currentWrongBones = new GameObject[200];

	public static GameObject[] bonesArray = new GameObject[200];

	static int wrongBonesCount=0;
	public BoneDbHandler db;
	int questionIndex=1;
	public static bool gameInProgress=false;
	public bool shouldSwitchQuestion=false;
	public Text boneName;
	public static int currentBoneId;
	public static int score=0;
	public static bool correctBoneClicked=false;
	public Text startBtnText;
	public Text scoreText;


	// Use this for initialization
	void Start () {

		db = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<BoneDbHandler> ();
		GameObject[] tempBonesArray = GameObject.FindGameObjectsWithTag ("Block");
		GameObject aux;
		for (int i = 0; i < tempBonesArray.Length; i++) {
		
			int properPos = tempBonesArray [i].GetComponent<ShowBoneInfo> ().id;
			bonesArray [properPos] = tempBonesArray [i];

		}


		score = 0;
	}

	public static void addWrongBone(GameObject bone)
	{
		wrongBonesCount++;
		currentWrongBones [wrongBonesCount] = bone;

	}

	public static void resetWrongBones()
	{
		for(int i=1;i<=wrongBonesCount;i++){
		
			currentWrongBones [i].GetComponent<MeshRenderer> ().material.color = currentWrongBones [i].GetComponent<onBoneClick> ().m_OriginalColor;

		}
		wrongBonesCount = 0;
	}

	void Update()
	{
		if (gameInProgress == true) {

			if (shouldSwitchQuestion == true)
				nextQuestion ();

			//gameInProgress = false;
		}
	}

	public void startGame()
	{
		if (gameInProgress == false) {
			score = 0;

			//reset facut toate intrebarile available
			for (int i = 1; i <= 80; i++)
				avaliableQuestions [i] = true;
			avaliableQuestions [8] = false;
			avaliableQuestions [6] = false;

			//scos intrebari care nu sunt valide




			questionIndex = 1;
			gameInProgress = true;
			shouldSwitchQuestion = true;
			startBtnText.text = "Stop";

		} else {
			gameInProgress = false;
			startBtnText.text = "Start";
			score = 0;
			scoreText.text = "Scor: 0";
			GameObject[] aux = GameObject.FindGameObjectsWithTag ("Block");
			foreach (GameObject go in aux) {

				go.GetComponent<MeshRenderer> ().material.color = onBoneClick.m_defaultBoneColor;
					go.GetComponent<MeshCollider> ().enabled = true;
			}

		}
	}

	public void nextQuestion()
	{
		//ales nr random
		int x;
		x = Random.Range (1, 101);
		while (avaliableQuestions [x] == false)
			x = Random.Range (1, 101);

		//pus text

		boneName.text = db.bonesArray.boneEntries [x].boneName;
		currentBoneId = db.bonesArray.boneEntries [x].Id;
		avaliableQuestions [x] = false;
		shouldSwitchQuestion = false;

	}


}
