using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    
    //private List<GameObject> activeTarget = new List<GameObject>();

    //public Transform playerTransform;

    //int numOfTargs = 3;
    // public float zSpawn = 0;
     private int targetIndex;
     private int xPos;
    //public GameObject targetPrefab;
    public float health = 30f;

    public Transform player;

    Score score;
    ObstacleController target;
    //TargetSpawner spawner = new TargetSpawner();    
    void Start(){
        Debug.Log("Start");
        score = FindObjectOfType<Score>();
    }

    void Update(){
        if(player.transform.position.z - 30 > gameObject.transform.position.z - 10){
            Spawn();
            Die();
        }
    }
    public void TakeDamage(float amount){
        //TargetSpawner ts = GetComponent<TargetSpawner>();
        health -= amount;
        if (health <= 0f){
            health += 30f; 
            score.TargetScore();
            Spawn();
            Die();
        }
         //StartCoroutine(Spawn());
    }

    void Die(){
        Destroy(gameObject);
    }

  
    public void Spawn(){
        //targetIndex = Random.Range(0,2);
        xPos = Random.Range(0, 2) * 5;
        Instantiate(gameObject, new Vector3(xPos, 1f, 55), Quaternion.identity);
        
    }    
}
