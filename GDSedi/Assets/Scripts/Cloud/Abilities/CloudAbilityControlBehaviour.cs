using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudAbilityControlBehaviour : MonoBehaviour {

	public GameObject selectedAbilityUI;

	public Sprite selectedOne;
	public Sprite selectedTwo;
	public Sprite selectedThree;
	public Sprite selectedFour;

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

		SpriteRenderer sr = selectedAbilityUI.GetComponent<SpriteRenderer>();
		switch (selected) {
			case 0:
				sr.sprite = selectedOne;
				break;
			case 1:
				sr.sprite = selectedTwo;
				break;
			case 2:
				sr.sprite = selectedThree;
				break;
			case 3:
				sr.sprite = selectedFour;
				break;
			default:
				break;

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
