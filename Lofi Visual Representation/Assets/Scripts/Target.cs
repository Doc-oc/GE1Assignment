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
    public float health = 20f;

    public Transform player;

    public bool next;
    Score score;
    //TargetSpawner spawner = new TargetSpawner();    
    void Start(){
        score = FindObjectOfType<Score>();
    }

    void Update(){
        //Spawning new Target one player has passed a certain point
        if(player.transform.position.z - 30 > gameObject.transform.position.z - 10){
            Spawn();
            Die(); //Destroying passed game Object
        }
    }

    //Function For Target Damage
    public void TakeDamage(float amount){
        //Taking 10 from health when target is hit
        //Called From GunController.cs script
        health -= amount;
        if (health <= 0f){
            health += 20f; //Resetting health
            score.TargetScore();//Adding to score
            Spawn();
            Die();
        }
         //StartCoroutine(Spawn());
    }

    void Die(){
        //Destroy game object attached
        Destroy(gameObject);
    }

    //Function that spawns the targets
    public void Spawn(){
        next = true;
        xPos = Random.Range(-1, 2) * 5;
        //Spawning two objects every time a hundred is hit else spawn 1 normally
        if(score.scoreText % 100 == 0){
            Instantiate(gameObject, new Vector3(xPos, 1f, 55), Quaternion.identity);
            xPos = Random.Range(1, 2) * 5;
            Instantiate(gameObject, new Vector3(xPos, 1f, 55), Quaternion.identity);
        } else {
             Instantiate(gameObject, new Vector3(xPos, 1f, 55), Quaternion.identity);
        }
        
    }    
}
