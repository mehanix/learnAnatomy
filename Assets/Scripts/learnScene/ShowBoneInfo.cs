using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ShowBoneInfo : MonoBehaviour {

	public BoneDbHandler db;
	public Text boneName;
	public Text description;
	public int id;
	string sceneName;
	public static GameObject backBtn;
	void Start() {
		
		db = GameObject.FindGameObjectWithTag("GameManager").GetComponent<BoneDbHandler> ();

		boneName = GameObject.FindGameObjectWithTag("boneNameText").GetComponent<Text>();
		if(GameObject.FindGameObjectWithTag ("descriptionText")!=null)
			description = GameObject.FindGameObjectWithTag ("descriptionText").GetComponent<Text>();
		sceneName = SceneManager.GetActiveScene ().name;

	
	}


	void OnMouseDown(){
		if (sceneName == "playScene" || sceneName=="learnSkull") {
			boneName.text = db.bonesArray.boneEntries [id].boneName;
			description.text = db.bonesArray.boneEntries [id].description;	
//			backBtn.SetActive (true);
		}
	
	}

	void OnMouseEnter() {
		if (sceneName == "playScene" || sceneName=="learnSkull") {
			boneName.text = db.bonesArray.boneEntries [id].boneName;
		}
	}
}
