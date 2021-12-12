using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
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
                SpawnRoad(0);
            } else {
                SpawnRoad(Random.Range(0, roadPrefabs.Length));
            }
        }
  
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z -35>zSpawn-(numOfRoads*roadLength)){
            SpawnRoad(Random.Range(0, roadPrefabs.Length));
            DeleteRoad();
        }
    }

    public void SpawnRoad(int roadIndex){
        GameObject gObj = Instantiate(roadPrefabs[roadIndex], transform.forward * zSpawn, transform.rotation );
        activeRoad.Add(gObj);
        zSpawn += roadLength;
    }

    

    private void DeleteRoad(){
        Destroy(activeRoad[0]);
        activeRoad.RemoveAt(0);
    }
}
