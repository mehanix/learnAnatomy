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
	int correctAnswer, userAnswer;
	int currentQuestionNr,totalQuestionNr;
	public questionCollection qCollection;
	public bool[] answered;
	// Use this for initialization
	void Start () {
		qCollection = JsonUtility.FromJson<questionCollection>(File.ReadAllText("intrebari.txt"));
		answered = new bool[qCollection.questions.Length];
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

	}
	void nextQuestion () {
		currentQuestionNr++;
		int questionIndex = getRandomNewIndex ();
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
		} while (answered [temp] == true);
		return temp;
	}
}
