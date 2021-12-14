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

    private int scoreText = 0;

    // Update is called once per frame
    void Start(){
        StartCoroutine(ScoreUpdate());
        target = FindObjectOfType<Target>();
    }

    public void TargetScore(){
        score.text = (scoreText += 30).ToString();
        
    }
    IEnumerator ScoreUpdate()
    {
        yield return new WaitForSeconds(2);
        score.text = (scoreText += 10).ToString();
        if(scoreText % 100 == 0){
            target.Spawn();
        }
        StartCoroutine(ScoreUpdate());
    }
}
