using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    public GameObject[] targetPrefab;
    private List<GameObject> activeTarget = new List<GameObject>();

    //public Transform playerTransform;

    //int numOfTargs = 3;
    // public float zSpawn = 0;
     private int targetIndex;
     private int xPos;
    //public GameObject targetPrefab;
    public float health = 30f;

    Score score;
    TargetSpawner target;
    //TargetSpawner spawner = new TargetSpawner();    
    void Start(){
        Debug.Log("Start");
        score = FindObjectOfType<Score>();
        target = FindObjectOfType<TargetSpawner>();
    }

    void Update(){
        //Spawn();
    }
    public void TakeDamage(float amount){
        //TargetSpawner ts = GetComponent<TargetSpawner>();
        health -= amount;
        if (health <= 0f){
            health += 30f; 
            score.TargetScore();
            target.Spawn(Random.Range(0,2));
            target.Die();  
        }
         //StartCoroutine(Spawn());
    }

}
