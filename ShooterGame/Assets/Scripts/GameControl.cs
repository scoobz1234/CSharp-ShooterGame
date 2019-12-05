using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

	public GameObject[] AsteroidsList;
	public GameObject PickedAsteroid, PickedAsteroid1, PickedAsteroid2,Ship0,Ship1,Ship2,Ship3,Ship4,Ship5,ShieldPowerUp,ExtraLife,SpeedPowerUp;
	private GameObject Shield;
	GameObject Player;
	public float Timer, Score, ShieldLeft, LivesLeft;
	public bool GameStart= false;
	public int ObjectPick, RollNumber, Index;
	public Transform SpawnPoint;
	public Text ScoreText, Lives, PlayerName;
	public bool GameOn =false;
	


void Awake (){
	Index = PlayerPrefs.GetInt ("ShipSelection");
	Ship0 = GameObject.Find ("Ship0");
	Ship1 = GameObject.Find ("Ship1");
	Ship2 = GameObject.Find ("Ship2");
	Ship3 = GameObject.Find ("Ship3");
	Ship4 = GameObject.Find ("Ship4");
	Ship5 = GameObject.Find ("Ship5");

	if(Index == 0){
		Ship0.SetActive(true);
		Ship1.SetActive(false);
		Ship2.SetActive(false);
		Ship3.SetActive(false);
		Ship4.SetActive(false);
		Ship5.SetActive(false);
		Player = GameObject.Find ("Ship0");
	}
	if (Index ==1){
		Ship0.SetActive(false);
		Ship1.SetActive(true);
		Ship2.SetActive(false);
		Ship3.SetActive(false);
		Ship4.SetActive(false);
		Ship5.SetActive(false);
		Player = GameObject.Find ("Ship1");
	}
		if (Index ==2){
		Ship0.SetActive(false);
		Ship1.SetActive(false);
		Ship2.SetActive(true);
		Ship3.SetActive(false);
		Ship4.SetActive(false);
		Ship5.SetActive(false);
		Player = GameObject.Find ("Ship2");
	}
		if (Index ==3){
		Ship0.SetActive(false);
		Ship1.SetActive(false);
		Ship2.SetActive(false);
		Ship3.SetActive(true);
		Ship4.SetActive(false);
		Ship5.SetActive(false);
		Player = GameObject.Find ("Ship3");
	}
		if (Index ==4){
		Ship0.SetActive(false);
		Ship1.SetActive(false);
		Ship2.SetActive(false);
		Ship3.SetActive(false);
		Ship4.SetActive(true);
		Ship5.SetActive(false);
		Player = GameObject.Find ("Ship4");
	}
		if (Index ==5){
		Ship0.SetActive(false);
		Ship1.SetActive(false);
		Ship2.SetActive(false);
		Ship3.SetActive(false);
		Ship4.SetActive(false);
		Ship5.SetActive(true);
		Player = GameObject.Find ("Ship5");
	}
}
	void Start () {
		LivesLeft = 3f;
		Shield = GameObject.FindWithTag ("Shield");
		Shield.SetActive (true);
		Score = 0;
		Timer = 0f;
		StartCoroutine (AsteroidSpawnerRoutine ());
		ShieldLeft = 10f;
		
	}

	void FixedUpdate () {
		PlayerName.text = "Name: "+ PlayerPrefs.GetString ("PlayerName").ToString();
		ScoreText.text = "Score: " + Score;
		Lives.text = "Lives: " + LivesLeft;
		Timer = Random.Range (0,100);
	
		if (ShieldLeft < 1f){
			Shield.SetActive (false);
		}
		else{
			ShieldLeft = ShieldLeft -Time.deltaTime;
			Shield.SetActive (true);
		}

	}
	void PickAndSpawnAsteroid (){

		if (Timer < 33) {

			RollNumber = Random.Range (0, AsteroidsList.Length);
			Vector3 ScreenLeft = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 10));
			Vector3 ScreenRight = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 10));
			Vector3 SpawnPointLocation = new Vector3 (Random.Range (ScreenLeft.x, ScreenRight.x), SpawnPoint.position.y, SpawnPoint.position.z);
			PickedAsteroid = AsteroidsList [RollNumber];
			Instantiate (PickedAsteroid, SpawnPointLocation, Quaternion.identity);
		}
		else if (Timer > 33 && Timer < 66){

			RollNumber = Random.Range (0, AsteroidsList.Length);
			Vector3 ScreenLeft = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 10));
			Vector3 ScreenRight = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 10));
			Vector3 SpawnPointLocation = new Vector3 (Random.Range (ScreenLeft.x, ScreenRight.x), SpawnPoint.position.y, SpawnPoint.position.z);
			PickedAsteroid = AsteroidsList [RollNumber];
			Instantiate (PickedAsteroid, SpawnPointLocation, Quaternion.identity);
				if (Timer >35 && Timer < 45){
					Vector3 ScreenLeft1 = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 10));
					Vector3 ScreenRight1 = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 10));
					Vector3 SpawnPointLocation1 = new Vector3 (Random.Range (ScreenLeft1.x, ScreenRight1.x), SpawnPoint.position.y, SpawnPoint.position.z);
					Instantiate (ShieldPowerUp, SpawnPointLocation1, Quaternion.identity);
				}
				if (Timer >45 && Timer < 50){
			
					Vector3 ScreenLeft1 = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 10));
					Vector3 ScreenRight1 = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 10));
					Vector3 SpawnPointLocation1 = new Vector3 (Random.Range (ScreenLeft1.x, ScreenRight1.x), SpawnPoint.position.y, SpawnPoint.position.z);
					Instantiate (ExtraLife, SpawnPointLocation1, Quaternion.identity);
				}
				if (Timer >55 && Timer < 60){
			
					Vector3 ScreenLeft1 = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 10));
					Vector3 ScreenRight1 = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 10));
					Vector3 SpawnPointLocation1 = new Vector3 (Random.Range (ScreenLeft1.x, ScreenRight1.x), SpawnPoint.position.y, SpawnPoint.position.z);
					Instantiate (SpeedPowerUp, SpawnPointLocation1, Quaternion.identity);
				}
		}
		
		else {
			RollNumber = Random.Range (0, AsteroidsList.Length);
			Vector3 ScreenLeft = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 10));
			Vector3 ScreenRight = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 10));
			Vector3 SpawnPointLocation = new Vector3 (Random.Range (ScreenLeft.x, ScreenRight.x), SpawnPoint.position.y, SpawnPoint.position.z);
			PickedAsteroid = AsteroidsList [RollNumber];
			Instantiate (PickedAsteroid, SpawnPointLocation, Quaternion.identity);

			RollNumber = Random.Range (0, AsteroidsList.Length);
			Vector3 SpawnPointLocation1 = new Vector3 (Random.Range (ScreenLeft.x, ScreenRight.x), SpawnPoint.position.y, SpawnPoint.position.z);
			PickedAsteroid1 = AsteroidsList [RollNumber];
			Instantiate (PickedAsteroid1, SpawnPointLocation1, Quaternion.identity);


		}

		

	}

	IEnumerator AsteroidSpawnerRoutine(){
		while (true) {
			PickAndSpawnAsteroid ();
			yield return new WaitForSeconds (Random.Range (.05f, 1f));
			if (!Player){
				Debug.Log ("NoPlayer");
				break;
			}
		}
	}
}