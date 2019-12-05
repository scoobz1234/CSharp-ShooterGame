using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour {
public float Timer=10f;
public AudioClip Pickup;
void Update(){
	Timer= Timer-Time.deltaTime;
	if (Timer<0){
		Destroy(gameObject);
	}
}
void OnTriggerEnter2D (Collider2D other){
	
	if (other.gameObject.tag =="Player"){
		AudioSource.PlayClipAtPoint(Pickup, new Vector3 (0,-6,0));
		Destroy (gameObject);
	}
}

}
