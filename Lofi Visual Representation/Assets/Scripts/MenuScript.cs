using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayGame(){
        Debug.Log("Pressed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
