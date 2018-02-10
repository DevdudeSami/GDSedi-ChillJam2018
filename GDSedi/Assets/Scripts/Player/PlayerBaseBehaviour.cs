using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseBehaviour : MonoBehaviour {

	public float speed = 2;

	private bool hasBoots = false;
	private bool hasUmbrella = false;
	private bool hasStunball = false;

	private int sadness = 0;

	private bool touchedSnow = false;
	private bool touchedWind = false;
	private bool touchedLightning = false;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	void OnTriggerEnter2D(Collider2D col) {
		PowerupBehaviour powerup = col.gameObject.GetComponent<PowerupBehaviour>();
		if(powerup != null) {
			touchedPowerup(powerup);
			return;
		}

		AbilityBehaviour ability = col.gameObject.GetComponent<AbilityBehaviour>();
		if(ability != null) {
			touchedAbility(ability);
			return;
		}
	}

	void touchedPowerup(PowerupBehaviour powerup) {
		switch(powerup.powerupType) {
			case "SpeedPowerup":
				StartCoroutine(getBoots(powerup.gameObject));
				break;
			case "UmbrellaPowerup":
				StartCoroutine(getUmbrella(powerup.gameObject));
				break;
			case "StunPowerup":
				StartCoroutine(getStunball(powerup.gameObject));
				break;
			default:
				break;
		}
	}

	void touchedAbility(AbilityBehaviour ability) {
		switch(ability.abilityType) {
			case "RainAbility":
				touchedRain();
				break;
			case "WindAbility":
				StartCoroutine(getWind(ability.gameObject));
				break;
			case "SnowAbility":
				StartCoroutine(getStunball(ability.gameObject));
				break;
			case "LightningAbility":
				StartCoroutine(getStunball(ability.gameObject));
				break;
			default:
				break;
		}
	}

	// Update is called once per frame
	void Update() {

	}

	private void touchedRain() {
		sadness -= 5;
	}

	private IEnumerator getWind(GameObject wind) {
		touchedWind = true;

		rb.AddForce(new Vector2(20, 0), ForceMode2D.Impulse);

		yield return new WaitForSeconds(2);
		removeWind();
	}
	private void removeWind() {
		touchedWind = false;
	}

	private IEnumerator getSnow() {
		touchedSnow = true;

		yield return new WaitForSeconds(2);
		removeSnow();
	}
	private void removeSnow() {
		touchedSnow = false;
	}

	private IEnumerator getLightning() {
		touchedLightning = true;

		yield return new WaitForSeconds(2);
		removeLightning();
	}
	private void removeLightning() {
		touchedLightning = false;
	}

	public bool canMove() {
		return !touchedLightning || !touchedWind;
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
