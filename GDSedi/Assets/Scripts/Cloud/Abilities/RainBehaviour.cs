using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainBehaviour : MonoBehaviour, CloudAbility {

	private int charges;
	private int maxCharges;

	public int GetCharges() {
		return charges;
	}

	void Awake() {

	}

	public bool PerformAbility() {
		if (charges <= 0) {
			return false;
		} else {
			charges--;
			//TODO
		}
	}


}
