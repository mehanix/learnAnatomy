using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BoneDbHandler : MonoBehaviour  {

	public BoneEntryArray bonesArray = new BoneEntryArray();
	TextAsset bonesFile;
	void Start() {
		bonesFile = new TextAsset ();
		bonesFile = Resources.Load ("bones") as TextAsset;
		Debug.Log (bonesFile.text.ToString());
		bonesArray = JsonUtility.FromJson<BoneEntryArray> (bonesFile.text);
	}
}
