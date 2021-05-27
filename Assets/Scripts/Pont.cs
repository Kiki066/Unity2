using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pont : MonoBehaviour
{
    [SerializeField]
    private int nbItem;

    [SerializeField]
    private GameObject pontConstruit;
    [SerializeField]
    private GameObject pontMoitie;
    [SerializeField]
    private GameObject pontDetruit;

    // Start is called before the first frame update
    void Start()
    {
            Debug.Log("startos");
        pontDetruit.SetActive(true);
        pontMoitie.SetActive(false);
        pontConstruit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (nbItem >= 3)
        {
            Debug.Log("troisos");
            pontDetruit.SetActive(false);
            pontMoitie.SetActive(true);
            pontConstruit.SetActive(false);
        }
        else if (nbItem > 4)
        {
            Debug.Log("cinquos");
            pontDetruit.SetActive(false);
            pontMoitie.SetActive(false);
            pontConstruit.SetActive(true);
        }
    }
}
