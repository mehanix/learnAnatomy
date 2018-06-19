using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class toggleSelect : MonoBehaviour {
	public GameObject groupToShow;
	bool state=true;
	public static Transform[] centers= new Transform[10];
	public static bool[] enabledCenters = new bool[10];
	public static int shownGroups=0;
	public static GameObject cameraCenter;
	public int id;
	// Use this for initialization
	public void Start()
	{
		shownGroups++;
		centers [shownGroups] = groupToShow.transform;
		enabledCenters [shownGroups] = true;
		id = shownGroups;
		cameraCenter = GameObject.FindGameObjectWithTag ("CameraCenter");
	}
	public void changeState()
	{
		state = !state;
		groupToShow.SetActive (state);
		enabledCenters [shownGroups] = state;
		cameraCenter.transform.position = recenter ();
	}

	public Vector3 recenter()
	{
		Vector3 newPos = new Vector3 ();
		int count = 0;
		for (int i = 1; i <= shownGroups; i++) {
			if (enabledCenters [i] == true) {
			
				newPos.x += centers [i].localPosition.x;
				newPos.y += centers [i].localPosition.y;
				newPos.z += centers [i].localPosition.z;
				count++;
			}
		}
		newPos.x /= count;
		newPos.y += 4.5f;
		newPos.y /= count;

		newPos.z /= count;

		return newPos;
	}
}
