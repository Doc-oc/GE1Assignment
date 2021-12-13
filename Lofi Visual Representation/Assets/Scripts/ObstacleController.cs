using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float speed = 5f;

    Target target;
    //      private bool going_right = false;
    
    void Start(){
        target = FindObjectOfType<Target>();

    }
    void Update() 
    {
        if(target.next){
            speed += 2f;
        }
        Debug.Log(speed);
        transform.Translate(Vector3.back * Time.deltaTime * speed); // Move right
        target.next = false;
    }
}