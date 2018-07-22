using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class QuizManager : MonoBehaviour {

	public Text questionNumber,
					  questionText,
					  answer1Text,
					  answer2Text,
					  answer0Text;
	int correctAnswer, userAnswer,questionIndex,score,totalQuestionsPerTest=9;
	int currentQuestionNr,totalQuestionNr=50;
	public questionCollection qCollection;
	public bool[] answered;

	public ToggleGroup t;
	// Use this for initialization
	void Start () {
		qCollection = JsonUtility.FromJson<questionCollection>(File.ReadAllText("intrebari.txt"));
		answered = new bool[qCollection.questions.Length];
		//Debug.Log (totalQuestionNr.ToString ());
		Initialise ();
		nextQuestion ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Initialise() {
		
		currentQuestionNr = 0;
		for (int i = 0; i < totalQuestionNr; i++)
			answered [i] = false;
		score = 0;
	}

	public void sendAnswer()
	{
		//checking answer
		userAnswer = getUserAnswer ();

		//check if anything selected
		if (userAnswer != -1) {


			if (userAnswer == correctAnswer)
				increaseScore ();

			//check if should switch to next q

			if (currentQuestionNr < totalQuestionsPerTest)
				nextQuestion ();
			else
				showResultScreen ();
		}
	

	}

	void increaseScore(){
	
		score++;
		//TODO UPDATE SCORE LABEL TEXT
	}

	void showResultScreen(){	
		//TODO ACTUALLY CREATE A RESULTS WINDOW LOL
	}

	int getUserAnswer() {
	
		//t.ActiveToggles
		return 1;
	}


	public void nextQuestion () {
		currentQuestionNr++;
		answered [questionIndex] = true;
		questionIndex = getRandomNewIndex ();
		questionNumber.text = "Intrebarea " + currentQuestionNr.ToString ();
		questionText.text = qCollection.questions [questionIndex].textIntrebare;
		answer0Text.text = qCollection.questions [questionIndex].raspunsuri [0];
		answer1Text.text = qCollection.questions [questionIndex].raspunsuri [1];
		answer2Text.text = qCollection.questions [questionIndex].raspunsuri [2];
		correctAnswer = qCollection.questions [questionIndex].raspunsCorect;

	}

	int getRandomNewIndex() {
	
		int temp;
		do {
			temp = Random.Range(0,totalQuestionNr);
		} while (answered [temp] == true && currentQuestionNr<49);
		return temp;
	}


}
