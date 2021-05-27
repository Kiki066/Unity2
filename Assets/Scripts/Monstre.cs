using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Monstre : MonoBehaviour
{

    AudioSource m_Source;

    private const float coefSpeed = 0.4f;

    

    [SerializeField]
    private float damage = 50f;

    [SerializeField]
    private AudioClip roar;

    [SerializeField]
    private NavMeshAgent monster;


    static Animator anim;

    [SerializeField]
    public Player player;

    int nbObjet;
    float speed;

    public float Damage
    {
        get
        {
            return damage;
        }
        set
        {
            this.damage = value;
        }
    }

    // Start is called before the first frame update
    public void Start()
    {
        nbObjet = player.objet.Count;
        anim = GetComponent<Animator>();
        m_Source = GetComponent<AudioSource>();
        monster = GetComponent<NavMeshAgent>();
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "leonard")
        {
            player.TakeDamage(Damage);
            if (player.Life <= 0)
            {
                
                SceneManager.LoadScene("Defaite");
                player.gameObject.SetActive(false);


            }

            anim.SetTrigger("isPunching");
            m_Source.clip = roar;
            m_Source.Play();

        }
       
            
    }

    private void Update()
    {
        if(player.objet.Count != nbObjet)
        {
            nbObjet = player.objet.Count;
            speed = monster.speed + player.objet.Count * coefSpeed;
            monster.speed = speed;
        }
        
    }


}
