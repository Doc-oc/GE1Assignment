using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public GameObject[] targetPrefabs;
    //private List<GameObject> activeTarget = new List<GameObject>();
    public GameObject obj;

    //public Transform playerTransform;

    //int numOfTargs = 3;
    // public float zSpawn = 0;
     private int targetIndex;
     private int xPos;


    void Start(){
        Debug.Log("Start");
        
    }

    void Update(){
        //Spawn();
    }
    public void TakeDamage(float amount){
        health -= amount;
        if (health <= 0f){
            Die();
            Spawn();   
        }
         //StartCoroutine(Spawn());

    }

    void Die(){
        Destroy(gameObject);
    }

    public void Spawn(){
        Debug.Log("Coroutine");
        targetIndex = 1;
        xPos = Random.Range(0, 2) * 5;
        Instantiate(targetPrefabs[targetIndex], new Vector3(xPos, 1f, 55), targetPrefabs[targetIndex].transform.rotation);
    }
}
