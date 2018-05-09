using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickBoneGameManager : MonoBehaviour {

	bool[] avaliableQuestions = new bool[150];
	public static GameObject[] currentWrongBones = new GameObject[150];
	static int wrongBonesCount=0;
	public BoneDbHandler db;
	int questionIndex=1;
	bool gameInProgress=false;
	public bool shouldSwitchQuestion=false;
	public Text boneName;
	public static int currentBoneId;
	public static int score=0;
	public Text startBtnText;

	// Use this for initialization
	void Start () {

		db = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<BoneDbHandler> ();

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
		
			currentWrongBones[i].GetComponent<MeshRenderer>().material.color = Color.white;

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
			for (int i = 1; i <= 102; i++)
				avaliableQuestions [i] = true;
			questionIndex = 1;
			gameInProgress = true;
			shouldSwitchQuestion = true;
			startBtnText.text = "Stop";

		} else {
			gameInProgress = false;
			startBtnText.text = "Start";
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
