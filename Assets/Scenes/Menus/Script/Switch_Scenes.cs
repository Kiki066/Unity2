using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch_Scenes : MonoBehaviour
{
    public void Play()
    {

        SceneManager.LoadScene("EndZone");
    }

    public void Pause()
    {
        SceneManager.LoadScene("EndZone");
    }

    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }
    

}
