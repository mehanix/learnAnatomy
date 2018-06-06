using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixBoneRotation : MonoBehaviour {

	Quaternion rotation;
	void Awake()
	{
		rotation = transform.rotation;
	}
	void LateUpdate()
	{
		transform.rotation = rotation;
	}
}
