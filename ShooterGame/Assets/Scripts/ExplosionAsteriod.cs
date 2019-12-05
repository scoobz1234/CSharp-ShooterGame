using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAsteriod : MonoBehaviour {

	float Lifetime = 3f;


	void Update (){
		Lifetime = Lifetime - Time.deltaTime;
		Destroy (gameObject, Lifetime);
	}


}
