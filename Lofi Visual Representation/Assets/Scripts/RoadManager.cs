using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    //Initialising Variables
    public GameObject[] roadPrefabs;
    public float zSpawn = 0;
    public float roadLength = 30;
    public int numOfRoads = 3;
    // Start is called before the first frame update
    public Transform playerTransform;

    private List<GameObject> activeRoad = new List<GameObject>();

    void Start()
    {
        for(int i=0; i<numOfRoads; i++){
            if(i==0){
                //Spawn first road in the list
                SpawnRoad(0);
            } else {
                //else spawn any road
                SpawnRoad(Random.Range(0, roadPrefabs.Length));
            }
        }
  
    }

    // Update is called once per frame
    void Update()
    {
        //If player is at a certain point spawn another road, give the endless runner effect
        if(playerTransform.position.z -35>zSpawn-(numOfRoads*roadLength)){
            SpawnRoad(Random.Range(0, roadPrefabs.Length));
            DeleteRoad();
        }
    }

    public void SpawnRoad(int roadIndex){
        //Create new game object (road) based on the z position of previous
        GameObject gObj = Instantiate(roadPrefabs[roadIndex], transform.forward * zSpawn, transform.rotation );
        activeRoad.Add(gObj);
        zSpawn += roadLength;
    }

    //Deleting put of scene Roads
    private void DeleteRoad(){
        Destroy(activeRoad[0]);
        activeRoad.RemoveAt(0);
    }
}
