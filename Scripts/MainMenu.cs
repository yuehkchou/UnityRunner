using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

public Text highscoreText;

	// Use this for initialization
	void Start () {
    highscoreText.text = "Highscore :" + PlayerPrefs.GetFloat("Highscore");
	}

	// Update is called once per frame
	void Update () {
	}

  public void ToGame() {
      SceneManager.LoadScene("EndlessRun");
  }
}
