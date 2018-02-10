using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovementBehaviour : MonoBehaviour {

	public float SPEED = 1f;

	private Rigidbody2D rb;

	void Awake () {
		rb = this.gameObject.GetComponent<Rigidbody2D>();
	}

	void Update () {
		float xSpeed = 0;
		float ySpeed = 0;

		if (Input.GetKey(KeyCode.W)) {
			ySpeed = SPEED;
		} else if (Input.GetKey(KeyCode.S)) {
			ySpeed= -SPEED;
		}

		if (Input.GetKey(KeyCode.A)) {
			xSpeed = -SPEED;
		} else if (Input.GetKey(KeyCode.D)) {
			xSpeed = SPEED;
		}

		rb.velocity = new Vector3(xSpeed, ySpeed, 0);
	}
}
