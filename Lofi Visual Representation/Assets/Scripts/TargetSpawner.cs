using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    private int xPos;
    
    void Awake(){
        Spawn();
    }

    public void Spawn(){
        Debug.Log("Coroutine");
        //targetIndex = Random.Range(0,2);
        xPos = Random.Range(0, 2) * 5;
        targetPrefab = Instantiate(targetPrefab, new Vector3(xPos, 1f, 55), Quaternion.identity) as GameObject;
    }
   
}
