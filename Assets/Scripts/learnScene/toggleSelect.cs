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
		//cameraCenter.transform.position = recenter ();
	}

//	public Vector3 recenter()
	//{
		///TODO FIND A WAY TO MAKE THIS WORK
		/*Vector3 minPoints = new Vector3 (999f,999f,999f);
		Vector3 maxPoints = new Vector3 (-999f,-999f,-999f);
		int count = 0;
		for (int i = 1; i <= shownGroups; i++) {
			if (enabledCenters [i] == true) {
			
				//min
				//if (centers [i].position.x < minPoints.x)
				//	minPoints.x = centers [i].position.x;
				if (centers [i].position.y < minPoints.y)
					minPoints.y = centers [i].position.y;
			//	if (centers [i].position.z < minPoints.z)
			//		minPoints.z = centers [i].position.z;

				//max
				//if (centers [i].position.x > minPoints.x)
				//	maxPoints.x = centers [i].position.x;
				if (centers [i].position.y > minPoints.y)
					maxPoints.y = centers [i].position.y;
			//	if (centers [i].position.z > minPoints.z)
			//		maxPoints.z = centers [i].position.z;
			}
		}
		Vector3 newPos = new Vector3 ();
		newPos = (minPoints + maxPoints) / 2;
		//newPos.y += 2.5f;
		newPos.x = cameraCenter.transform.position.x;
		newPos.z = cameraCenter.transform.position.z;



		return newPos;
		*/
	//}
}
