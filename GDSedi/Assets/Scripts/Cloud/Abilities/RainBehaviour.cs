using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainBehaviour : MonoBehaviour {


	public float startingHeight;
	public float destinationHeight;
	public float fallDistance;

	void Start () {
		startingHeight = this.gameObject.transform.position.y;
		destinationHeight = startingHeight - fallDistance;
	}

	void OnTrigger2D(Collider2D coll) {
		PlayerMovementBehaviour player = coll.gameObject.GetComponent<PlayerMovementBehaviour>();
		if (player != null) {

		}
	}

	void Update () {
		Vector3 pos = this.gameObject.transform.position;
 		if (pos.y - destinationHeight < 0) {
			Destroy(this.gameObject);
		} else if (pos.y - destinationHeight < 0.5f) {
			GetComponent<BoxCollider2D>().enabled = true;
		}
	}
}
