using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zoom : MonoBehaviour {

	public Vector3 camPos;
	public Transform camTr;
	public float speed = 2.5f;
	public GameManager gm;
	public static GameObject[] blocks;
	string sceneName;
	void Start() {
		
		camTr  = Camera.main.transform;
		camPos = camTr.position;
		blocks = GameObject.FindGameObjectsWithTag ("Block");
		sceneName = SceneManager.GetActiveScene ().name;
	}

	void Update() {
		if(sceneName=="playScene" || sceneName=="learnSkull")
			if (Input.GetMouseButtonDown (0)) {
				RaycastHit hit;
				gm.isZoomed = true;
				var ray = Camera.main.ScreenPointToRay (Input.mousePosition);



				if (Physics.Raycast (ray, out hit) && hit.collider.tag == "Block") {
					foreach (GameObject go in blocks) {
						if (go == hit.collider.gameObject) {
							camPos.x = go.transform.position.x;
							camPos.y = go.transform.position.y;
							camPos.z += 5.0f; // Zoom
						} else {
							go.SetActive (false);

						}
					}
				}
			}
		if (gm.isZoomed == true) {
			camTr.position = Vector3.Lerp (camTr.position, camPos, Time.deltaTime * speed);
		}
	}
}
