using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
private float speed = 5f;
private bool going_right = false;

void Update() 
{
    if(going_right) 
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed); // Move right
        if(transform.position.x > 5) // Too far right
        { 
            going_right = false; // Switch direction
        }
    }
    else 
    {
        transform.Translate(-Vector3.right * Time.deltaTime * speed); // Move left
        if(transform.position.x < -5) // Too far left
        { 
            going_right = true; // Switch direction
        }
    }
}
}
