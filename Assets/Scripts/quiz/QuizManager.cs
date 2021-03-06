﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour {

	public Text questionNumber,
					  questionText,
					  answer1Text,
					  answer2Text,
					  answer0Text;
	int correctAnswer, userAnswer,questionIndex,score,totalQuestionsPerTest=10;
	int currentQuestionNr,totalQuestionNr=26;
	public questionCollection qCollection;
	public bool[] answered;
	ColorBlock cbCorrect,cbWrong,cbNeutral;

	public GameObject greetingWindow, quizWindow,resultsWindow,validateAnsBtn,nextQuestionBtn;
	public Toggle ans0, ans1, ans2;
	public Text scoreLabel,resultLabel;

	TextAsset questionsData;
	// Use this for initialization
	void Start () {
		questionsData = Resources.Load ("intrebari") as TextAsset;
		qCollection = JsonUtility.FromJson<questionCollection>(questionsData.text);
		answered = new bool[qCollection.questions.Length];
		//Debug.Log (totalQuestionNr.ToString ());
		startQuiz();
	}

	public void startQuiz()
	{
		Initialise ();
		nextQuestion ();
	
		greetingWindow.SetActive (false);
		resultsWindow.SetActive (false);

		quizWindow.SetActive (true);
		cbCorrect = new ColorBlock ();
		cbWrong = new ColorBlock ();
		cbCorrect = cbWrong = ans0.colors;
		cbNeutral = ans0.colors;
		cbCorrect.disabledColor = Color.green;
		cbWrong.disabledColor = Color.red;

		cbCorrect.normalColor = Color.green;
		cbWrong.normalColor = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Initialise() {
		
		currentQuestionNr = 0;
		for (int i = 0; i < totalQuestionNr; i++)
			answered [i] = false;
		score = 0;
		scoreLabel.text = "Scor: 0/10";
	}

	public void sendAnswer()
	{
		//checking answer
		userAnswer = getUserAnswer ();
		Debug.Log (userAnswer.ToString ());
		//check if anything selected
		if (userAnswer != -1) {


			if (userAnswer == correctAnswer)
				increaseScore ();

			//check if should switch to next q

			if (currentQuestionNr < totalQuestionsPerTest) {
				validateAnsBtn.SetActive (false);
				nextQuestionBtn.SetActive (true);

				ans0.enabled = false;
				ans1.enabled = false;
				ans2.enabled = false;

			
			

				switch (correctAnswer) {

				case 0:
					{
						ans0.colors = cbCorrect;
						ans1.colors = cbWrong;
						ans2.colors = cbWrong;
						break;
					}
				case 1:
					{
						ans0.colors = cbWrong;
						ans1.colors = cbCorrect;
						ans2.colors = cbWrong;
						break;
					}
				case 2:
					{
						ans0.colors = cbWrong;
						ans1.colors = cbWrong;
						ans2.colors = cbCorrect;
						break;
					}
				}
			}
		
			else {
				quizWindow.SetActive (false);
				showResultScreen ();
			}
				
		}
	

	}

	void increaseScore(){
	
		score++;
		scoreLabel.text = "Scor: " + score + "/10";
	}

	void showResultScreen(){	
		//TODO ACTUALLY CREATE A RESULTS WINDOW LOL
		resultsWindow.SetActive(true);
		resultLabel.text = "Testul s-a incheiat! Ai obtinut nota: " + score.ToString();
	}

	int getUserAnswer() {
	
		if (ans0.isOn == true)
			return 0;
		if (ans1.isOn == true)
			return 1;
		if (ans2.isOn == true)
			return 2;
		
		return -1;
	}

	public void goToNextQuestion(){
	
		ans0.colors = cbNeutral;
		ans1.colors = cbNeutral;
		ans2.colors = cbNeutral;

		ans0.isOn = false;
		ans1.isOn = false;
		ans2.isOn = false;

		nextQuestion ();
	}


	void nextQuestion () {
		currentQuestionNr++;
		answered [questionIndex] = true;
		questionIndex = getRandomNewIndex ();
		questionNumber.text = "Intrebarea " + currentQuestionNr.ToString ();
		questionText.text = qCollection.questions [questionIndex].textIntrebare;
		answer0Text.text = qCollection.questions [questionIndex].raspunsuri [0];
		answer1Text.text = qCollection.questions [questionIndex].raspunsuri [1];
		answer2Text.text = qCollection.questions [questionIndex].raspunsuri [2];
		correctAnswer = qCollection.questions [questionIndex].raspunsCorect;
		nextQuestionBtn.SetActive (false);
		validateAnsBtn.SetActive (true);

		ans0.enabled = true;
		ans1.enabled = true;
		ans2.enabled = true;





	}

	int getRandomNewIndex() {
	
		int temp;
		do {
			temp = Random.Range(0,totalQuestionNr);
		} while (answered [temp] == true && currentQuestionNr<49);
		return temp;
	}

	public void backToMenu()
	{
		SceneManager.LoadScene ("menu");
	}
}
