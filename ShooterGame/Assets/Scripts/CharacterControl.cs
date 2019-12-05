using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CharacterControl : MonoBehaviour {


	public float Speed = 5f, nextFire = 0.5f, fireRate=0.5f, SpeedTimer;
	public GameObject Player, Laser;
	public Transform PlayerPos, LaserSpawn;
	Transform LastPosition;
	public int Index;
	public Renderer rend;
	public Collider2D Col;
	public AudioClip PlayerDeath, PickUp;
	

	void Awake (){
	Index = PlayerPrefs.GetInt ("ShipSelection");


	if(Index == 0){
		Player = GameObject.Find ("Ship0");
	}
	if (Index ==1){
		Player = GameObject.Find ("Ship1");
	}
		if (Index ==2){
		Player = GameObject.Find ("Ship2");
	}
		if (Index ==3){
		Player = GameObject.Find ("Ship3");
	}
		if (Index ==4){
		Player = GameObject.Find ("Ship4");
	}
		if (Index ==5){
		Player = GameObject.Find ("Ship5");
	}
	}


	void Update(){
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (Laser, LaserSpawn.position, LaserSpawn.rotation);
			}
		if (SpeedTimer < 1){
			Speed = 5f;
			Debug.Log ("NormSpeed");
		}
		else {
			Speed =10f;
			SpeedTimer = SpeedTimer - Time.deltaTime;
			Debug.Log("SupaSpeed");
		} 
		
	}


	void FixedUpdate () {

		if (Input.GetKey (KeyCode.Mouse0)) {
			//Gets the Mouse Position on screen
			Vector3 screenPos = Input.mousePosition;
			//Translates Mouse/Screen Position to a world point position
			Vector3 mousePos = Camera.main.ScreenToWorldPoint (screenPos);
			//the following code clamps (locks) my X axis to the left most and right most positions of the screen
			mousePos.x = Mathf.Clamp (mousePos.x, -2.62f, 2.62f);
			//the following code clamps (locks) my Y axis to the bottom of the screen
			mousePos.y = Mathf.Clamp (mousePos.y, -4.53f, .03f);
			//the following code clamps (locks) my Z axis to 0
			mousePos.z = Mathf.Clamp (mousePos.z, 0f, 0f);
			
			// gotta initialize it first, otherwise it might freak out that Radian might not exist when it gets to the next part.
			float Radian = 0;
			// compare the position of the sprite with the position of the mouse
			if(Camera.main.WorldToScreenPoint(PlayerPos.position).x > Input.mousePosition.x) {
				Radian = Mathf.Atan2 (Input.mousePosition.y - transform.position.y, Input.mousePosition.x - transform.position.x);
			} else {
				Radian = Mathf.Atan2 (transform.position.y - Input.mousePosition.y, transform.position.x - Input.mousePosition.x);
			}
			// everything else is the same
			float Degree = (360 / Mathf.PI) * Radian;
			Degree = Mathf.Clamp (Degree, -45f, 45f);

			PlayerPos.rotation = Quaternion.Slerp(PlayerPos.rotation, Quaternion.Euler(0, Degree, 0), Time.fixedDeltaTime * Speed);

			//makes the player follow the mouse position and multiplies its movement speed by time and the speed variable
			PlayerPos.position = Vector3.Lerp (PlayerPos.position, mousePos, Time.deltaTime * Speed);
		
		}

	}



	void OnTriggerEnter2D (Collider2D other) {
		GameObject Lives = GameObject.Find ("GameMaster");
		GameControl GameControl = Lives.GetComponent<GameControl> ();
		if (other.gameObject.tag == "Asteroid") {
			GameControl.LivesLeft--;
			if (GameControl.LivesLeft > 0) {
				StartCoroutine (Dead());
			}
			else if (GameControl.LivesLeft <1){
				String Score = GameControl.Score.ToString();
				PlayerPrefs.SetString ("Score", Score);
				SceneManager.LoadScene (2);
			}
	
		} 
		else if (other.gameObject.tag == "EnemyLaser") {
		//	Destroy (GameObject.FindWithTag("Player"));
			GameControl.LivesLeft--;
						if (GameControl.LivesLeft > 0) {
				StartCoroutine (Dead());
			}
			else if (GameControl.LivesLeft <1){
				String Score = GameControl.Score.ToString();
				PlayerPrefs.SetString ("Score", Score);
				SceneManager.LoadScene (2);
			}		
		}
		else if (other.gameObject.tag == "Enemy") {
			GameControl.LivesLeft--;
			if (GameControl.LivesLeft > 0) {
				StartCoroutine (Dead());
			}
			else if (GameControl.LivesLeft <1){
				String Score = GameControl.Score.ToString();
				PlayerPrefs.SetString ("Score", Score);
				SceneManager.LoadScene (2);
			}
		}	
		else if (other.gameObject.tag =="ShieldPowerUp"){
			GameControl.ShieldLeft =10f;
		}
		else if (other.gameObject.tag =="ExtraLife"){
			GameControl.LivesLeft++;
		}
		else if (other.gameObject.tag =="SpeedPowerUp"){
			SpeedTimer = 10f;
			
		}

	}

 	IEnumerator Dead() {
		GameObject Lives = GameObject.Find ("GameMaster");
		GameControl GameControl = Lives.GetComponent<GameControl> ();
     	Debug.Log ("dead");
		AudioSource.PlayClipAtPoint(PlayerDeath, new Vector3 (0,-6,0));
    	rend = Player.GetComponent<Renderer>();
		rend.enabled = false;
		Col = GetComponent<CircleCollider2D>();
		Col.enabled = false;
		Debug.Log ("DisabledCollider");
		 yield return new WaitForSeconds(3f);
    	 Debug.Log ("respawn");
		 rend.enabled = true;
		 GameControl.ShieldLeft +=10f;
		 Col.enabled = true;
 }
}
