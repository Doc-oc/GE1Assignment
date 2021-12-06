using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 10f;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    Rigidbody rb;

    public SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 3.0f, 0.0f);
    }

    void OnCollisionStay(){
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        float horMovement = Input.GetAxis("Horizontal") * speed;
        float verMovement = Input.GetAxis("Vertical") * speed;

        transform.Translate(new Vector3(horMovement, 0, verMovement) * Time.deltaTime);
    }

    private void onTriggerEnter(Collider other){
        spawnManager.SpawnTriggerEntered();
    }
}
