using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Initialising Variables
    public float speed = 10f;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    Rigidbody rb;
    Score score;

    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<Score>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {   //Setting speed of each axis (Speed = 10)
        float horMovement = Input.GetAxis("Horizontal") * speed;
        float verMovement = Input.GetAxis("Vertical") * speed;
        //Move player 
        transform.Translate(new Vector3(horMovement, 0, verMovement) * Time.deltaTime);

        //If user moves forward add 10
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            score.MoveScore();
        } else if (Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene("SampleScene"); //Restart Game
        }
    }

    //Collider Function
    void OnCollisionEnter(Collision Col) {
        if(Col.collider.tag == "Target")
        {
            //Reload Game if you hit target
            SceneManager.LoadScene("Menu");
        }
        
    }

}
