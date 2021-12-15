using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Target target;
    public Transform player;
    public Text score;
    private ObstacleController obstacle;

    public int scoreText = 0;

    //Once game is loaded
    void Start(){
        //StartCoroutine to add score every 2 seconds
        StartCoroutine(ScoreUpdate());

        //If target object is not attached to Score, Find it
        target = FindObjectOfType<Target>();
    }

    //Function to calculate hitting a target
    public void TargetScore(){
        score.text = (scoreText += 10).ToString();
    }

    //Function to calculate moving forward
    public void MoveScore(){
        score.text = (scoreText += 10).ToString();
    }

    //Coroutine
    IEnumerator ScoreUpdate()
    {
        //Wait two seconds
        yield return new WaitForSeconds(2);
        score.text = (scoreText += 10).ToString(); //adding 10 to score every 2 seconds
        StartCoroutine(ScoreUpdate());//Recalling Coroutine
    }
}
