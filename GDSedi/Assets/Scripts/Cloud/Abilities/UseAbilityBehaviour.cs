using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAbilityBehaviour : MonoBehaviour {

	public GameObject prefab;

	private int charges;
	public int maxCharges;
	public int rechargeInterval;

	private int frame = 0;

	public int GetCharges() {
		return charges;
	}

	void Awake() {
		charges = 1;
	}

	void Update() {
		frame++;
		if (frame % rechargeInterval == 0) {
			if (charges < maxCharges) {
				charges++;
			}
		}
		if (charges == maxCharges) {
			frame = 0;
		}
	}

	public bool PerformAbility() {
		if (charges <= 0) {
			return false;
		}
		charges--;

		Vector3 pos = this.gameObject.transform.position;
		GameObject ability = Instantiate(prefab, new Vector3(pos.x, pos.y - 0.5f, 0), Quaternion.identity) as GameObject;

		return true;
	}


}
