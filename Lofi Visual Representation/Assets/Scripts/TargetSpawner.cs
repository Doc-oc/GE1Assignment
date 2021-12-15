using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    //Initialising Variables
    public GameObject targetPrefab;
    
    private int xPos;
    
    void Awake(){
        //Spawn First target
        Spawn();
    }

    //Spawn Target
    public void Spawn(){
        Debug.Log("Coroutine");
        //targetIndex = Random.Range(0,2);
        xPos = Random.Range(-1, 2) * 5;
        targetPrefab = Instantiate(targetPrefab, new Vector3(xPos, 1f, 55), Quaternion.identity) as GameObject;
    }
   
}
