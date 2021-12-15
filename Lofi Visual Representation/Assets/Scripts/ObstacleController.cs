using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float speed = 5f;

    Target target;
    
    void Start(){
        target = FindObjectOfType<Target>();
    }
    void Update() 
    {
        //if a new target spawns , increase speed
        if(target.next){
            speed += 2f;
        }
        //Move target back towards player
        transform.Translate(Vector3.back * Time.deltaTime * speed); // Move back
        target.next = false;
    }
}