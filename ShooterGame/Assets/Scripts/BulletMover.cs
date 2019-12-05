using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour {

    float thrust =500f, Timer;
	public Rigidbody2D Rb;

	void Start () {

		Timer = 3f;

		Rb = GetComponent<Rigidbody2D> ();

		Rb.AddForce (Vector3.up * thrust);

	}
	void FixedUpdate (){
		if (Timer < 1f) {
			Destroy (gameObject);
		}
		else if (Timer > 1f) {
			Timer = Timer - Time.deltaTime;
		}
	}
	void OnTriggerEnter2D (Collider2D other){
		GameObject PlayerScore = GameObject.Find ("GameMaster");
		GameControl GameControl = PlayerScore.GetComponent<GameControl> ();

		if (other.gameObject.tag == "Asteroid") {
			Destroy (gameObject);
			GameControl.Score++;
		}
		else if (other.gameObject.tag == "Enemy") {
			Destroy (gameObject);
			GameControl.Score++;
		}
		else if (other.gameObject.tag == "EnemyLaser") {
			Destroy (gameObject);
			GameControl.Score++;
		}

	}
}
