using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    Rigidbody rb;
    
    Score score;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        score = FindObjectOfType<Score>();
    }

    void OnCollisionStay(){
        isGrounded = true;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        float horMovement = Input.GetAxis("Horizontal") * speed;
        float verMovement = Input.GetAxis("Vertical") * speed;
        transform.Translate(new Vector3(horMovement, 0, verMovement) * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.UpArrow)){
            score.MoveScore();
        }
    }


    void OnCollisionEnter(Collision Col) {
        Debug.Log("OnCollision");
        if(Col.collider.tag == "Target")
        {
            Debug.Log("OnCollision IF");
            //Replace 'Game Over' with your game over scene's name.
            SceneManager.LoadScene("SampleScene");
        }
        
    }

}
