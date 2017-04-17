using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private float score = 0.0f;

    public Text scoreText;
    private float difficultyLevel = 1;
    private float maxDifficultyLevel = 10;
    private float scoreToNextLevel = 10;

    private bool isDead = false;

    // Use this for initialization
    void Start () {

	}

	// Update is called once per frame
	void Update () {

        if(isDead) {
            return;
        }
        score += Time.deltaTime;
        if (score >= scoreToNextLevel)
            LevelUp();
        scoreText.text = ((int)score).ToString();
	}
    void LevelUp() {
        scoreToNextLevel *= 2;
        difficultyLevel++;
        GetComponent<Runner>().SetSpeed(difficultyLevel);
    }

    public void onDeath() {
        isDead = true;
    }
}
