using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float life = 100f;

    [SerializeField]
    private GameObject spawn;


  


    //[SerializeField]
    //public Monstre monstre;

    public float Life 
    {
        get
        {
            return life;
        }
        set
        {
            this.life = value;
        }
    }

    private void Start()
    { 
        player = GetComponent<GameObject>();
        //Vector3 spawnPos = spawn.transform.position;
        //player.transform.position = spawnPos;
    }

    private void Update()
    {


    }

    

    public void TakeDamage(float damage)
    {
        Life -= damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectable")
        {
                other.gameObject.SetActive(false);
        }
    }


}
