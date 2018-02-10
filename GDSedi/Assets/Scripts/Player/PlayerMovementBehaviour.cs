using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour {

	public GameObject footstepPrefab;

	public float speed = 2.0f;

	private Vector3 currentSpeed = new Vector3(0, 0, 0);
	private Rigidbody2D rb;

	private SpriteRenderer renderer;

	private int footstepTimer = 0;
	private const int footstepInterval = 12;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
		renderer = GetComponent<SpriteRenderer>();
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
			renderer.flipX = true;
		} else if(Input.GetKey(KeyCode.RightArrow)) {
			currentSpeed.x = speed;
			renderer.flipX = false;
		} else {
			currentSpeed.x = 0;
		}

		rb.velocity = currentSpeed;

		updateFootstep();
	}

	private void updateFootstep() {
		footstepTimer++;

		if(footstepTimer == footstepInterval) {
			footstepTimer = 0;

			Instantiate(footstepPrefab, new Vector3(transform.position.x, transform.position.y-renderer.bounds.size.y/2, transform.position.z), Quaternion.identity);
		}
	}
}
