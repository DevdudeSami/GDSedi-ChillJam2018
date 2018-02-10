using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainBehaviour : MonoBehaviour {

	private int liveFrames;
	private int frames;

	void Start () {
		liveFrames = 20;
	}

	void OnTrigger2D(Collider2D coll) {
		// PlayerMovement player = coll.gameObject.GetComponent<PlayerMovement>();
		// if (player != null) {

		// }
	}

	void Update () {
		if (frames > liveFrames) {
			Destroy(this.gameObject);
		}
		frames++;
	}
}
