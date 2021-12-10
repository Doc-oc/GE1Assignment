using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject[] targetPrefab;
    private List<GameObject> activeTarget = new List<GameObject>();
    public float health = 50f;
    public float zSpawn = 0;
    public int numOfTargs= 3;
    public Transform playerTransform;

    void Start()
    {
        for(int i=0; i<numOfTargs; i++){
            SpawnTarget(Random.Range(0, targetPrefab.Length));
            Debug.Log(targetPrefab.Length);
        }
  
    }
    void Update()
    {
        if(playerTransform.position.z > gameObject.transform.position.z || activeTarget.Count < 1){
            Debug.Log("IN");
            SpawnTarget(Random.Range(0, targetPrefab.Length));
            Die();
        }
    }

    public void SpawnTarget(int tarIndex){
        GameObject tObj = Instantiate(targetPrefab[tarIndex], transform.forward * zSpawn, transform.rotation);
        //activeTarget.Add(tObj);
        //zSpawn += 20;
    }

    public void TakeDamage(float amount){
        health -= amount;
        if (health <= 0f){
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
        //activeTarget.RemoveAt(0);
    }

    

}
