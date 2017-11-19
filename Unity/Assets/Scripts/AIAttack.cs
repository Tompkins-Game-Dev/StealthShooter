using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttack : MonoBehaviour {

	public float melee_range, ranged_range, move_speed, turn_speed;

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (transform.position, player.transform.position) <= melee_range) {
			Vector3 target = player.transform.position - transform.position;
 			float angle = Mathf.Atan2 (target.y, target.x) * Mathf.Rad2Deg;
 			Quaternion rotation = Quaternion.AngleAxis (angle, Vector3.forward);
 			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, turn_speed * Time.deltaTime);
			transform.position = Vector3.MoveTowards (transform.position, player.transform.position, (move_speed / 10));
		} else if (Vector3.Distance (transform.position, player.transform.position) > melee_range && Vector3.Distance (transform.position, player.transform.position) <= ranged_range) {
			Vector3 target = player.transform.position - transform.position;
 			float angle = Mathf.Atan2 (target.y, target.x) * Mathf.Rad2Deg;
 			Quaternion rotation = Quaternion.AngleAxis (angle, Vector3.forward);
 			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, turn_speed * Time.deltaTime);
			transform.position = Vector3.MoveTowards (transform.position, new Vector3 (transform.position.x + Vector3.Distance (transform.position, player.transform.position), transform.position.y + Vector3.Distance (transform.position, player.transform.position), transform.position.z), (move_speed / 10));
		}
	}
}
