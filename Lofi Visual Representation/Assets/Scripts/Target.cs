using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    //Inititialising Variables
     private int targetIndex;
     private int xPos;
    //public GameObject targetPrefab;
    public float health = 30f;

    public Transform player;

    public bool next;

    Score score;
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
        next = true;
        xPos = Random.Range(-1, 2) * 5;
        if(score.scoreText % 100 == 0){
            Instantiate(gameObject, new Vector3(xPos, 1f, 55), Quaternion.identity);
            xPos = Random.Range(1, 2) * 5;
            Instantiate(gameObject, new Vector3(xPos, 1f, 55), Quaternion.identity);
        } else {
             Instantiate(gameObject, new Vector3(xPos, 1f, 55), Quaternion.identity);
        }
        
    }    
}
