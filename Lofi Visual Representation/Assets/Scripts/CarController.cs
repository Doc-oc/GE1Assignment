using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horMovement = Input.GetAxis("Horizontal") * speed / 2;
        float verMovement = Input.GetAxis("Vertical") * speed;

        transform.Translate(new Vector3(horMovement, 0, verMovement) * Time.deltaTime);
    }
}
