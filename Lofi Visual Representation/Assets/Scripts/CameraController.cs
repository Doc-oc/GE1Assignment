using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Transform car;

    private float zOffset = -4f;
    private float yOffset = 1f;
    
    // Start is called before the first frame update
    void Start()
    { 
        car = GameObject.Find("Car").transform;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(car.position.x, car.position.y + yOffset, car.position.z + zOffset);
    }
}
