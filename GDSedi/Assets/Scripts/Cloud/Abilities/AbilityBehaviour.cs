using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBehaviour : MonoBehaviour {

	private float startingHeight;
	private float destinationHeight;
	public float fallDistance;
	public string abilityType;

	void Start () {
		startingHeight = this.gameObject.transform.position.y;
		destinationHeight = startingHeight - fallDistance;
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
