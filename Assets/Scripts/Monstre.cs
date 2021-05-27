using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monstre : MonoBehaviour
{

    AudioSource m_Source;


    [SerializeField]
    private float damage = 50f;

    [SerializeField]
    private AudioClip roar;



    static Animator anim;

    [SerializeField]
    public Player player;

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
    void Start()
    {
        anim = GetComponent<Animator>();
        m_Source = GetComponent<AudioSource>();
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
        
       
    }


}
