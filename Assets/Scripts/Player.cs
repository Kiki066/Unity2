using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    AudioSource m_Source;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float life = 100f;

    [SerializeField]
    private GameObject spawn;

    public List<string> objet;


    [SerializeField]
    public AudioClip hurt;

    [SerializeField]
    public AudioClip run;

    [SerializeField]
    public GameObject HurtPanel;


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
        m_Source = GetComponent<AudioSource>();
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
                objet.Add(other.gameObject.name);
        }

        if(other.gameObject.tag == "Helico")
        {
            SceneManager.LoadScene("Victoire");
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Monstre")
        {
            HurtPanel.SetActive(true);
            m_Source.clip = hurt;
            m_Source.Play();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Monstre")
        {
            HurtPanel.SetActive(false);
            m_Source.Stop();
            m_Source.clip = run;
            m_Source.Play();
        }
    }




}
