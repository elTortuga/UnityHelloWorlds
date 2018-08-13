using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GoToGameScene() {
		SceneManager.LoadScene("Game", LoadSceneMode.Single);
	}
	public void GoToSettingsScene() {
		SceneManager.LoadScene("Settings", LoadSceneMode.Additive);
	}
	public void EndGame() {
		Application.Quit();
		
	}
}
