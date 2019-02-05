using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HighlightBone : MonoBehaviour {

	//When the mouse hovers over the GameObject, it turns to this color (red)
	Color m_MouseOverColor = Color.blue;
	//This stores the GameObject’s original color
	public static Color m_OriginalColor;
	//Get the GameObject’s mesh renderer to access the GameObject’s material and color
	MeshRenderer m_Renderer;
	public GameManager gm;
	string sceneName;
	void Start()
	{
		//Fetch the mesh renderer component from the GameObject
		if (gameObject.GetComponent<MeshRenderer> () != null) {
			m_Renderer = GetComponent<MeshRenderer> ();
			//Fetch the original color of the GameObject
			m_OriginalColor = m_Renderer.material.color;
		}
		sceneName = SceneManager.GetActiveScene ().name;
		gm = GameObject.FindWithTag ("GameManager").GetComponent<GameManager>();
	}

	void OnMouseOver()
	{
		//Change the color of the GameObject to red when the mouse is over GameObject
		if((sceneName=="pickBone" && pickBoneGameManager.gameInProgress == true) || (sceneName=="playScene" || sceneName=="learnSkull"))
			if(m_Renderer.material.color==m_OriginalColor)
			{
				m_Renderer.material.color = m_MouseOverColor;
			}
	}

	void OnMouseExit()
	{
		//Reset the color of the GameObject back to normal
		if(m_Renderer.material.color==m_MouseOverColor)
			m_Renderer.material.color = m_OriginalColor;
		
	}

	void OnMouseDown()
	{
		if ((sceneName=="playScene" || sceneName=="learnSkull") || (sceneName=="pickBone" && pickBoneGameManager.correctBoneClicked==true))
		gm.cameraFocusPoint.transform.position = gameObject.transform.position;
	}
}
