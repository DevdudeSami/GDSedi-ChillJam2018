using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepBehaviour : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start() {
		yield return new WaitForSeconds(0.75f);
		destroy();
	}

	private void destroy() {
		Destroy(gameObject);
	}

}
