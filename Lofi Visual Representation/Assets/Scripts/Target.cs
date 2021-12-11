using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public GameObject[] targetPrefabs;
    private List<GameObject> activeTarget = new List<GameObject>();

    void Start(){
        Spawn(Random.Range(0, targetPrefabs.Length));
    }

    void Update(){
        //Spawn(Random.Range(0, targetPrefabs.Length));
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
        GameObject gObj = Instantiate(targetPrefabs[targetIndex], transform.position , transform.rotation);
        activeTarget.Add(gObj);
    }
}
