using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public GameObject[] targetPrefabs;
    private List<GameObject> activeTarget = new List<GameObject>();

    public Transform playerTransform;

    int numOfTargs = 3;
     public float zSpawn = 0;


    void Start(){
        for(int i=0; i< numOfTargs; i++){
            if(i==0){
                Spawn(Random.Range(0, targetPrefabs.Length));
            }
        }
    }

    void Update(){
        if(playerTransform.position.z -35>zSpawn-(numOfTargs*10)){
            Spawn(Random.Range(0, targetPrefabs.Length));
            //DeleteRoad();
        }
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

    public void Spawn(int targetIndex){
        GameObject gObj = Instantiate(targetPrefabs[targetIndex], transform.position, transform.rotation);
        activeTarget.Add(gObj);
        zSpawn += 10;
    }
}
