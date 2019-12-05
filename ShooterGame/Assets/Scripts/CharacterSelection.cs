using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CharacterSelection : MonoBehaviour {

	public List<GameObject> CharacterList;
	public Text PlayerNameInput;
	private string PlayerName;

public int index = 0;
public float CharRot;

	void Start () {

		GameObject[] characters = Resources.LoadAll<GameObject>("Prefab");
		foreach(GameObject c in characters) {

			GameObject _char = Instantiate (c) as GameObject;
			_char.transform.SetParent(GameObject.Find("CharacterList").transform);

			CharacterList.Add(_char);
			_char.SetActive(false);
			CharacterList[index].SetActive(true);
		}
	}
	
	void Update () {
		CharacterList[index].transform.Rotate (0,0,CharRot);

	}
	void FixedUpdate(){
		PlayerName = PlayerNameInput.text.ToString();
	}
	public void Next(){
		CharacterList[index].SetActive (false);
		CharRot = Random.Range (0.5f,-0.5f);
		if(index == CharacterList.Count -1){
			index =0;
		}
		else {
		index++;
		}
		CharacterList [index].SetActive (true);
	}
		public void GameStart(){
			PlayerPrefs.SetString ("PlayerName", PlayerName);
			PlayerPrefs.SetInt ("ShipSelection", index);
			SceneManager.LoadScene (1);
	}
	
}
