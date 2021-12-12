using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject[] targetPrefab;

    private List<GameObject> activeTarget = new List<GameObject>();
    private int targetIndex;
    private int xPos;
    
    void Start(){
        Spawn(Random.Range(0, 2));
    }

    public void Spawn(int index){
        Debug.Log("Coroutine");
        //targetIndex = 2;
        xPos =  Random.Range(0, 2) * 5;
        targetPrefab[index] = Instantiate(targetPrefab[targetIndex], new Vector3(xPos, 1f, 55), Quaternion.identity) as GameObject;
        activeTarget.Add(targetPrefab[index]);
    }

    public void Die(){
        Destroy(activeTarget[0]);
        activeTarget.RemoveAt(0);
    }
   
}
