using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float speed = 10f;
    //      private bool going_right = false;

    void Update() 
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed); // Move right
    }
}