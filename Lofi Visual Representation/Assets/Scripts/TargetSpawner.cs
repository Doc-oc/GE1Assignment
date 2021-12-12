using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject[] targetPrefab;

    private List<GameObject> activeTarget = new List<GameObject>();
    private int targetIndex;
    private int xPos;
    
    void Awake(){
        Spawn();
    }

    public void Spawn(){
        Debug.Log("Coroutine");
        targetIndex = Random.Range(0, 2);
        xPos =  Random.Range(0, 2) * 5;
        targetPrefab[targetIndex] = Instantiate(targetPrefab[targetIndex], new Vector3(xPos, 1f, 55), Quaternion.identity) as GameObject;
        activeTarget.Add(targetPrefab[targetIndex]);
    }

    public void Die(){
        Destroy(activeTarget[0]);
        activeTarget.RemoveAt(0);
    }
   
}
