using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public GameObject[] targetPrefabs;
    //private List<GameObject> activeTarget = new List<GameObject>();

    //public Transform playerTransform;

    //int numOfTargs = 3;
    // public float zSpawn = 0;
     private int targetIndex;
     private int xPos;


    void Start(){
        Debug.Log("Start");
        StartCoroutine(Spawn());
    }

    void Update(){
        
    }
    public void TakeDamage(float amount){
        health -= amount;
        if (health <= 0f){
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
    }

    IEnumerator Spawn(){
        Debug.Log("Coroutine");
        yield return new WaitForSeconds(1);
        targetIndex = Random.Range(0,2);
        xPos = Random.Range(0, 2) * 5;
        Instantiate(targetPrefabs[targetIndex], new Vector3(xPos, .0f, 55), targetPrefabs[targetIndex].transform.rotation);
        StartCoroutine(Spawn());
    }
}
