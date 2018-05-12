using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class TestHandler : MonoBehaviour {

	public int nrOfQuestions;
	public bool[] usedQuestions = new bool[50]; //TODO SCHIMBA!!!!!!!!!!!
	public GameObject nrQuestionsInputField;
	public questionCollection intrebari;
	public int chosenIndex;
	public void init() {
		nrOfQuestions = int.Parse (nrQuestionsInputField.GetComponent<Text> ().text);
		intrebari = JsonUtility.FromJson<questionCollection> (File.ReadAllText ("intrebari.txt"));
		for (int i = 0; i < 51; i++)
		{
			usedQuestions [i] = false;
		}
	}

	public void nextQuestion() {
		
		do {
			 chosenIndex = Random.Range (0, nrOfQuestions);
		} while (usedQuestions [chosenIndex] == true);
	}


}
