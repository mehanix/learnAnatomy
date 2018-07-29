using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class manager : MonoBehaviour {

	public question[] q = new question[50];

	public InputField qText,ans0,ans1,ans2;
	public Text label;
	//public InputField qTextField,ans0field,ans1field,ans2field;
	public Toggle t0,t1,t2;
	int index=0;
	// Use this for initialization
	void Start () {
		index = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addQuestion() {

		if (getCorrectAns () != -1) {
			
		q[index]= new question();

			q [index].textIntrebare = qText.text;
			q [index].raspunsuri[0] = ans0.text;
			q [index].raspunsuri[1] = ans1.text;
			q [index].raspunsuri[2] = ans2.text;

			q [index].raspunsCorect = getCorrectAns ();
		
		
			index++;

			qText.text = "";
			ans0.text = "";
			ans1.text = "";
			ans2.text = "";

			label.text = "Intrebarea Nr: " + index;
			t0.enabled = false;
			t1.enabled = false;
			t2.enabled = false;
		}

	}

	int getCorrectAns() 
	{
		if (t0.isOn ==true)
			return 0;
		if (t1.isOn ==true)
			return 1;
		if (t2.isOn==true)
			return 2;
		return -1;
	}

	public void saveFile() {
	
		questionCollection qc = new questionCollection ();
		qc.questions = q;

		string text = JsonUtility.ToJson(qc,true);

		File.WriteAllText ("intrebari.txt", text);
		label.text = "Fisier creat cu succes!";
	}

	public void exit()
	{

		Application.Quit ();
	}
}
