using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserMover : MonoBehaviour {


	float thrust =500f, Timer;
	public Rigidbody2D Rb;

	void Start () {

		Timer = 3f;

		Rb = GetComponent<Rigidbody2D> ();

		Rb.AddForce (Vector3.down * thrust);

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
		if (other.gameObject.tag == "Laser") {
			Destroy (gameObject);
		}
		else if (other.gameObject.tag == "Player") {
			Destroy (gameObject);
		}	
		else if (other.gameObject.tag == "Shield") {
			Destroy (gameObject);
		}


	}
}
