using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    
        //private List<GameObject> activeTarget = new List<GameObject>();

    //public Transform playerTransform;

    //int numOfTargs = 3;
    // public float zSpawn = 0;
     private int targetIndex;
     private int xPos;
    //public GameObject targetPrefab;
    public float health = 50f;

    

    //TargetSpawner spawner = new TargetSpawner();    
    void Start(){
        Debug.Log("Start");        
    }

    void Update(){
        //Spawn();
    }
    public void TakeDamage(float amount){
        
        //TargetSpawner ts = GetComponent<TargetSpawner>();
        health -= amount;
        if (health <= 0f){
            
            Spawn();
            
            Die();  
            health += 50f;
        }
         //StartCoroutine(Spawn());
 
    }

    void Die(){
        Destroy(gameObject);
    }

  
    public void Spawn(){
        Debug.Log("Coroutine");
        //targetIndex = Random.Range(0,2);
        xPos = Random.Range(0, 2) * 5;
        Instantiate(gameObject, new Vector3(xPos, 1f, 55), Quaternion.identity);
        
    }

    

    
}
