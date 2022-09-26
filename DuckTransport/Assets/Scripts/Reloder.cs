using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reloder : MonoBehaviour
{
   
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetButtonDown("Fire2"))
        {

            Application.Quit();
            

        }

        if (Input.GetButtonDown("Fire3"))
        {
            Screen.fullScreen = !Screen.fullScreen;
        }


    }
}
