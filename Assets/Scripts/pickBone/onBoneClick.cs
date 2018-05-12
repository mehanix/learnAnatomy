using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onBoneClick : MonoBehaviour {


	//daca e osu bun treci la urmatoru si fa-l verde si aduna 1 pct la scor
	//else fa-l rosu

	// Use this for initialization

	//ia componenta showboneinfo ca in ea am idu
	ShowBoneInfo boneinfo;
	public Text scoreText;
	MeshRenderer m_Renderer;
	Color m_green = Color.green;
	Color m_red = Color.red;
	public static Color m_defaultBoneColor;
	public Color m_OriginalColor;
	public static Text skipBtnText;


	void Start () {
		boneinfo = gameObject.GetComponent<ShowBoneInfo> ();

		if (gameObject.GetComponent<MeshRenderer> () != null) {
			m_Renderer = GetComponent<MeshRenderer> ();
			m_OriginalColor = m_Renderer.material.color;

		}
		try {
			m_defaultBoneColor = m_Renderer.material.color;
		} catch { } ;

			
		skipBtnText = GameObject.FindGameObjectWithTag ("skipButtonText").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
			
	}

	void OnMouseDown()
	{
		//daca am dat click pe osu corect
		if (pickBoneGameManager.gameInProgress == true) {
			
				if (boneinfo.id == pickBoneGameManager.currentBoneId) {

					pickBoneGameManager.score++;
					scoreText.text = "Scor: " + pickBoneGameManager.score;

					//culoarea
					changeBoneColor(Color.green);
					pickBoneGameManager.resetWrongBones ();

					//facut manevra la buton

					skipBtnText.text = "Urmator";
					pickBoneGameManager.correctBoneClicked = true;
					m_OriginalColor = m_Renderer.material.color;
					GetComponent<MeshCollider> ().enabled = false;

				} else {
					pickBoneGameManager.addWrongBone (gameObject);
					changeBoneColor(Color.red);
				}


		}

	}

	public void changeBoneColor(Color c)
	{
		m_Renderer.material.color = c;
	}
}
