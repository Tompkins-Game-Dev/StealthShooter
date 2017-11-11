using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Rigidbody projectile;
	public KeyCode attack;
	public float movement_speed, projectile_speed;

	private Camera cam;
	private Rigidbody2D body;

	void Start () {
		cam = Camera.main;
		body = GetComponent <Rigidbody2D> ();
	}

	void Update () {
		Vector3 position_two = cam.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10));
		Vector3 movement_vector = new Vector3 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"), 0).normalized;
		position_two = transform.position - position_two;

		if (position_two.y < 0) {
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, Mathf.Rad2Deg * (Mathf.Asin (position_two.x / position_two.magnitude))));
		} else {
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 180 - (Mathf.Rad2Deg * (Mathf.Asin (position_two.x / position_two.magnitude)))));
		}

		body.MovePosition (transform.position + new Vector3 (movement_vector.x * movement_speed, movement_vector.y * movement_speed) * Time.deltaTime);

		if (Input.GetKeyUp (attack)) {
			Rigidbody new_projectile = (Rigidbody) Instantiate (projectile, transform.position + (transform.up * 2), transform.rotation);
			new_projectile.AddForce (transform.up * projectile_speed);
		}
	}
}
