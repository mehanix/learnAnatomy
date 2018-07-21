using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;
public class menuToggle : MonoBehaviour,IPointerDownHandler  {


	public Animator anim;
	public GameObject pointerArrow;
	public void OnPointerDown (PointerEventData eventData)
	{Debug.Log ("bonk");
		int state = anim.GetInteger("currentState");
		if (state == 0 || state == 2)
			anim.SetInteger ("currentState", 1);
		else if (state == 1)
			anim.SetInteger ("currentState", 2);
		pointerArrow.transform.Rotate (new Vector3 (180, 0, 0));
		Debug.Log (anim.GetInteger("currentState").ToString());
	}


}
