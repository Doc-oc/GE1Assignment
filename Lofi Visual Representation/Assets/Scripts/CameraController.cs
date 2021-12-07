using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Transform car;

    private float zOffset = -9f;
    private float yOffset = 2f;
    
    // Start is called before the first frame update
    void Start()
    { 
        car = GameObject.Find("Spaceship").transform;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(car.position.x, car.position.y + yOffset, car.position.z + zOffset);
    }
}
