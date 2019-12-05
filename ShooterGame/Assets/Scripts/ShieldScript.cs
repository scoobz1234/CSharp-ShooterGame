using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		GameObject Lives = GameObject.Find ("GameMaster");
		GameControl GameMaster = Lives.GetComponent<GameControl> ();
	
		if (other.gameObject.tag == "Asteroid") {
			Destroy (gameObject);
			GameMaster.ShieldLeft--;
		} else if (other.gameObject.tag == "EnemyLaser") {
			Destroy (gameObject);
			GameMaster.ShieldLeft--;
		} else if (other.gameObject.tag == "Enemy") {
			Destroy (gameObject);
			GameMaster.ShieldLeft--;
		}
	}
}
