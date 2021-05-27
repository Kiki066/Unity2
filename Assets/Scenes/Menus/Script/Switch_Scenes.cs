using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Switch_Scenes : MonoBehaviour
{
    public Text text;



    public void Pause()
    {
        SceneManager.LoadScene("JulesScene sans eau");
    }

    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Option()
    {
        SceneManager.LoadScene("Option");
    }

    public void Quitter()
    {
        Application.Quit();
    }

    public void CouleurMenu()
    {
        text.color = new Color(179f, 27f, 27f);
    }
    

}
