using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch_Scenes : MonoBehaviour
{
    public void Play()
    {

        SceneManager.LoadScene("JulesScene sans eau");
    }

    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }
    

}
