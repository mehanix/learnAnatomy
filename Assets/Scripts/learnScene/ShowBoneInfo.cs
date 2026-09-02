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
	public GameObject backBtn;
	void Start() {
		GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
		if (gm != null)
			db = gm.GetComponent<BoneDbHandler>();

		GameObject nameObj = GameObject.FindGameObjectWithTag("boneNameText");
		if (nameObj != null)
			boneName = nameObj.GetComponent<Text>();

		GameObject descObj = GameObject.FindGameObjectWithTag("descriptionText");
		if (descObj != null)
			description = descObj.GetComponent<Text>();

		sceneName = SceneManager.GetActiveScene().name;
		if (backBtn != null)
			backBtn.SetActive(false);
	}


	void OnMouseDown(){
		if ((sceneName == "playScene" || sceneName == "learnSkull") && db != null && boneName != null) {
			boneName.text = db.bonesArray.boneEntries[id].boneName;
			if (description != null)
				description.text = db.bonesArray.boneEntries[id].description;	
			if (backBtn != null)
				backBtn.SetActive(true);
		}
	
	}

	void OnMouseEnter() {
		if ((sceneName == "playScene" || sceneName == "learnSkull") && db != null && boneName != null) {
			boneName.text = db.bonesArray.boneEntries[id].boneName;
		}
	}
}
