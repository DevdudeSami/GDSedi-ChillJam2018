using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudAbilityControlBehaviour : MonoBehaviour {

	private int selected;
	private CloudAbility[] abilites;

	void Awake() {
		abilites = this.gameObject.GetComponents<CloudAbility>();
		selected = 0;
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Q)) {
			Prev();
		} else if (Input.GetKeyDown(KeyCode.E)) {
			Next();
		} else if (Input.GetKeyDown(KeyCode.Space)) {
			UseSelectedAbility();
		}
	}

	void UseSelectedAbility() {
		if (!abilites[selected].PerformAbility()) {
			// play fail sound
		}
	}

	void Next() {
		selected = (selected + 1) % abilites.Length;
	}
	void Prev() {
		selected = (selected - 1) % abilites.Length;
	}
}
