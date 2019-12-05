using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

	float LifeSpan, thrust, nextFire = 1.0f, fireRate=1.0f;
    public Rigidbody2D rb;
	public GameObject Laser;
	public Transform LaserSpawn, LaserSpawn2;
    public GameObject Explosion;

	public AudioClip ExplosionSound, LaserSound;

    void Start()
    {

		rb = GetComponent<Rigidbody2D>();
        thrust = -9f;
        LifeSpan = 10f;


    }

	void Update (){
		if (Time.time > nextFire) {

			nextFire = Time.time + fireRate;
			AudioSource.PlayClipAtPoint(LaserSound, new Vector3 (0,-6,0));
			Instantiate (Laser, LaserSpawn.position, LaserSpawn.rotation);
			

			Instantiate (Laser, LaserSpawn2.position, LaserSpawn2.rotation);

		}
	}


    void FixedUpdate()
    {

        rb.AddForce(Vector3.down * thrust);

        if (LifeSpan < 1f)
        {
            Destroy(gameObject);
            LifeSpan = Random.Range(1f, 5f);
        }
        else
        {
            LifeSpan = LifeSpan - Time.deltaTime;
        }

       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.gameObject.tag == "Player") {
			Destroy (gameObject);
            StartCoroutine (BlowUp());
		}
		if (other.gameObject.tag == "Laser") {
			Destroy (gameObject);
            StartCoroutine (BlowUp());
		}
		else if (other.gameObject.tag == "Shield") {
			Destroy (gameObject);
            StartCoroutine (BlowUp());
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
