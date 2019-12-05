using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour {

public Text ScoreText;


	void Update () {
		ScoreText.text = PlayerPrefs.GetString ("Score").ToString();
	}

	public void Restartgame (){
		SceneManager.LoadScene (0);
	}
}
