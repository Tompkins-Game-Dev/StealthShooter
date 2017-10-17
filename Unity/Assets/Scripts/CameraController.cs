using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	Transform cam;
	GameObject player;
	Transform target;

	void Start () {
		cam = gameObject.transform;
		foreach (Transform t in FindObjectsOfType<Transform>()) {
			if (t.name == "Player") {
				player = t.gameObject;
				break;
			}
		}
		target = player.transform;
	}
		
	void Update () {
		if (cam != null && target != null) {
			cam.transform.transform.position = new Vector3 (
				Mathf.Lerp (cam.position.x, target.position.x, 0.2f), 
				Mathf.Lerp (cam.position.y, target.position.y, 0.2f),
				-10
			);
		}
	}

	void SetTarget(Transform t) {
		target = t;
	}

	void SetTarget() {
		target = player.transform;
	}
}
