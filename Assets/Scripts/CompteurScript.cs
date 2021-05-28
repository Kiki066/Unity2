using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CompteurScript : MonoBehaviour
{
    public Text compteur;
    public Player player;

    public void Update()
    {
        compteur.text = "Nombre d'items : "+player.objet.Count;
    }

}
