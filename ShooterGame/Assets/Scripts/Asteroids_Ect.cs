using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids_Ect : MonoBehaviour {
	float LifeSpan, SpinVelocity =50f, thrust;
	Vector3 Rotation, Torque;
	public Rigidbody2D rb;
	public GameObject Explosion, Explosion2, Explosion3;

	public AudioClip ExplosionSound;


	void Start () {

		Rotation = Random.onUnitSphere;
		Rotation.y = Mathf.Clamp (Rotation.y, 0f, 0f);
		Rotation.x = Mathf.Clamp (Rotation.x, 0f, 0f);
		rb = GetComponent<Rigidbody2D>();
		thrust = Random.Range (-10f, 10f);
		if (thrust > -5){
			LifeSpan = Random.Range (3f, 5f);
		}
		else if (thrust < -5 ){
			LifeSpan = Random.Range (10f, 15f);
		}

	}


	void FixedUpdate () {
		transform.Rotate (Rotation, SpinVelocity * Time.smoothDeltaTime);

		rb.AddForce (Vector3.down * thrust);
	
		if (LifeSpan < 1f) {
			Destroy (gameObject);
			LifeSpan = Random.Range (1f, 5f);
		}
		else {
			LifeSpan = LifeSpan- Time.deltaTime;
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player") {
			Destroy (gameObject);
			StartCoroutine (BlowUp ());
		}
		else if (other.gameObject.tag == "Laser") {
			Destroy (gameObject);
			StartCoroutine (BlowUp ());
		} 
		else if (other.gameObject.tag == "Shield") {
			
			Destroy (gameObject);
			StartCoroutine (BlowUp ());
		}

	}
		IEnumerator BlowUp(){
		while (true) {
			Instantiate (Explosion, gameObject.transform.position , gameObject.transform.rotation);
			AudioSource.PlayClipAtPoint(ExplosionSound, new Vector3 (0,-6,0));
			yield return new WaitForSeconds (.5f);
			Destroy (Explosion);
			break;
		}
	}
}