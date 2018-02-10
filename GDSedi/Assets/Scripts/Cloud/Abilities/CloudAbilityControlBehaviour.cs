using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudAbilityControlBehaviour : MonoBehaviour {

	public GameObject selectedAbilityUI;

	private int selected;
	private UseAbilityBehaviour[] abilites;

	void Awake() {
		abilites = this.gameObject.GetComponents<UseAbilityBehaviour>();
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
		print(selected);
	}
	void Prev() {
		selected--;
		if (selected < 0) {
			selected = abilites.Length - 1;
		}
		print(selected);
	}
}
