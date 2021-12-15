using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Target target;
    public Transform player;
    public Text score;
    public Text highscore;
    private ObstacleController obstacle;
    public int highscoreText = 0;

    public int scoreText;

    string highscoreKey = "Highscore: ";

    //Once game is loaded
    void Start(){
        scoreText = 0;
        //StartCoroutine to add score every 2 seconds
        StartCoroutine(ScoreUpdate());
        highscoreText = PlayerPrefs.GetInt(highscoreKey, 0); 
        highscore.text = "Highscore: " + highscoreText;   
        //If target object is not attached to Score, Find it
        target = FindObjectOfType<Target>();
    }

    void Update(){
        //adding highscore
        if (highscoreText < scoreText) {
            //Puts score into the highscore key
            PlayerPrefs.SetInt(highscoreKey, scoreText);
            //Saves the keys
            PlayerPrefs.Save();
        }
    }

    //Function to calculate hitting a target
    public void TargetScore(){
        score.text = (scoreText = scoreText + 10).ToString();
    }

    //Function to calculate moving forward
    public void MoveScore(){
        score.text = (scoreText = scoreText + 10).ToString();
    }

    //Coroutine
    IEnumerator ScoreUpdate()
    {
        //Wait two seconds
        yield return new WaitForSeconds(2);
        score.text = (scoreText = scoreText + 10).ToString(); //adding 10 to score every 2 seconds
    }
}
