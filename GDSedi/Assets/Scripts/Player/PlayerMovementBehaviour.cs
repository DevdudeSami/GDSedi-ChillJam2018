using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour {

	public float speed = 2.0f;

	private Vector3 currentSpeed = new Vector3(0, 0, 0);

	private Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody>();
	}

	void Update() {
		if(Input.GetKey(KeyCode.UpArrow)) {
			currentSpeed.y = speed;
		} else if(Input.GetKey(KeyCode.DownArrow)) {
			currentSpeed.y = -speed;
		} else {
			currentSpeed.y = 0;
		}

		if(Input.GetKey(KeyCode.LeftArrow)) {
			currentSpeed.x = -speed;
		} else if(Input.GetKey(KeyCode.RightArrow)) {
			currentSpeed.x = speed;
		} else {
			currentSpeed.x = 0;
		}

		rb.velocity = currentSpeed;
	}
}
