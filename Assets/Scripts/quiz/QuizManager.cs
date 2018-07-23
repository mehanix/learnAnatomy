using System.Collections;
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
	int currentQuestionNr,totalQuestionNr=50;
	public questionCollection qCollection;
	public bool[] answered;

	public GameObject greetingWindow, quizWindow,resultsWindow;
	public Toggle ans0, ans1, ans2;
	public Text scoreLabel,resultLabel;
	// Use this for initialization
	void Start () {
		qCollection = JsonUtility.FromJson<questionCollection>(File.ReadAllText("intrebari.txt"));
		answered = new bool[qCollection.questions.Length];
		//Debug.Log (totalQuestionNr.ToString ());
	
	}

	public void startQuiz()
	{
		Initialise ();
		nextQuestion ();
		greetingWindow.SetActive (false);
		resultsWindow.SetActive (false);

		quizWindow.SetActive (true);
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
		Debug.Log (userAnswer.ToString ());
		//check if anything selected
		if (userAnswer != -1) {


			if (userAnswer == correctAnswer)
				increaseScore ();

			//check if should switch to next q

			if (currentQuestionNr < totalQuestionsPerTest)
				nextQuestion ();
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
