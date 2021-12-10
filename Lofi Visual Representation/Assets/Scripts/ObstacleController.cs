using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{   
    private float speed = 3f;
    private bool going_right = false;

     public float yDistance = 10;
    public float minSpread = 5;
    public float maxSpread = 10;
    
    public Transform playerTransform;
    public Transform obstaclePrefab;
    
    float ySpread;
    float lastYPos;
    
    void Start(){
        ySpread = Random.Range(minSpread, maxSpread);
        lastYPos = playerTransform.position.y + (startDistance - ySpread - yDistance);
    }
    
    void Update () {
        if(playerTransform.position.y - lastYPos >= ySpread){
            float lanePos = Random.Range(0, 3);
            lanePos = (lanePos-1)*1.5f;
            Instantiate(obstaclePrefab, new Vector3(lanePos, lastYPos + ySpread + yDistance, 0), Quaternion.identity);
            
            lastYPos += ySpread;
            ySpread = Random.Range(minSpread, maxSpread);
        }
    }
}