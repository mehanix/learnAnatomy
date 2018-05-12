using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BoneDbHandler : MonoBehaviour  {

	public BoneEntryArray bonesArray = new BoneEntryArray();

	void Start() {
	
		bonesArray = JsonUtility.FromJson<BoneEntryArray> (File.ReadAllText ("bones.json"));
	}
}
