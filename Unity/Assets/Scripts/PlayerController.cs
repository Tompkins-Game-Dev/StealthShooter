using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	Camera cam;

	void Start() {
		cam = Camera.main;
	}

	void Update() {
		Vector3 pos2 = cam.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10));
		pos2 = transform.position - pos2;
		if(pos2.y<0)
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, Mathf.Rad2Deg*(Mathf.Asin (pos2.x / pos2.magnitude))));
		else
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 180-(Mathf.Rad2Deg*(Mathf.Asin (pos2.x / pos2.magnitude)))));
		Debug.Log (pos2 + " " + new Vector3 (0, 0, Mathf.Asin (pos2.x / pos2.magnitude)));


	}
}
