using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBehaviour : MonoBehaviour {

	public GameObject bolt;

	private GameObject boltInstance;

	private int frame;

	void Start () {
		Vector3 pos = this.gameObject.transform.position;
		boltInstance = Instantiate(bolt, new Vector3(pos.x, pos.y, 0), Quaternion.identity) as GameObject;
	}


	void Update () {
		if (boltInstance != null) {
			boltInstance.GetComponent<SpriteRenderer>().enabled = !boltInstance.GetComponent<SpriteRenderer>().enabled;
		}
		if (frame > 15) {
			Destroy(boltInstance);
			this.enabled = false;
		}

		frame++;
	}
}
