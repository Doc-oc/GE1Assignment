using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    //Initialising variable
    private Transform spaceship;
    private float zOffset = -9f;
    private float yOffset = 2f;
    
    // Start is called before the first frame update
    void Start()
    { 
        spaceship = GameObject.Find("Spaceship").transform;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Camera follow the space based on x,y,z coordinates of spaceship
        transform.position = new Vector3(spaceship.position.x, spaceship.position.y + yOffset, spaceship.position.z + zOffset);
    }
}
