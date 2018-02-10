using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovementBehaviour : MonoBehaviour {

	public float SPEED = 1f;
	public GameObject shadow;

	private GameObject shadowInstance;

	private Rigidbody2D rb;

	void Awake () {
		rb = this.gameObject.GetComponent<Rigidbody2D>();
		Vector3 pos = this.gameObject.transform.position;
		shadowInstance = Instantiate(shadow, new Vector3(pos.x, pos.y - 4f, 0), Quaternion.identity) as GameObject;
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
		Vector3 pos = this.gameObject.transform.position;
		shadowInstance.transform.position = new Vector3(pos.x, pos.y - 4f, 0);
	}
}
