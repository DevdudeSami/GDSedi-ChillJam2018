using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseBehaviour : MonoBehaviour {

	public float speed = 2;

	private bool hasBoots = false;
	private bool hasUmbrella = false;
	private bool hasStunball = false;

	private int sadness;



	// Use this for initialization
	void Start() {
		sadness = 0;
	}

	void OnTriggerEnter2D(Collider2D col) {
		PowerupBehaviour powerup = col.gameObject.GetComponent<PowerupBehaviour>();
		if(powerup == null) return;

		switch(powerup.powerupType) {
			case "SpeedPowerup":
				StartCoroutine(getBoots(col.gameObject));
				break;
			case "UmbrellaPowerup":
				break;
			case "StunPowerup":
				break;
			default:
				break;
		}
	}

	// Update is called once per frame
	void Update() {

	}

	private IEnumerator getBoots(GameObject bootsPowerup) {
		Destroy(bootsPowerup);
		this.hasBoots = true;
		this.speed += 5;

		yield return new WaitForSeconds(4);
		removeBoots();
	}
	private void removeBoots() {
		this.hasBoots = false;
		this.speed -= 5;
	}

	private IEnumerator getUmbrella(GameObject umbrellaPowerup) {
		Destroy(umbrellaPowerup);
		this.hasUmbrella = true;

		yield return new WaitForSeconds(4);
		removeUmbrella();
	}
	private void removeUmbrella() {
		this.hasUmbrella = false;
	}

	private IEnumerator getStunball(GameObject stunPowerup) {
		Destroy(stunPowerup);
		this.hasStunball = true;

		yield return new WaitForSeconds(4);
		removeStunball();
	}
	private void removeStunball() {
		this.hasStunball = false;
	}
}
