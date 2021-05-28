using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pont : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private GameObject pontConstruit;
    [SerializeField]
    private GameObject pontMoitie;
    [SerializeField]
    private GameObject pontDetruit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.objet.Count < 1)
        {
            pontDetruit.SetActive(true);
            pontMoitie.SetActive(false);
            pontConstruit.SetActive(false);
        }
        else if (player.objet.Count < 2)
        {
            pontDetruit.SetActive(false);
            pontMoitie.SetActive(true);
            pontConstruit.SetActive(false);
        }
        else
        {
            pontDetruit.SetActive(false);
            pontMoitie.SetActive(false);
            pontConstruit.SetActive(true);
        }
    }
}
