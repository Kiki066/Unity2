using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Piege : MonoBehaviour
{
    static Animator anim;

    public GameObject trap;

    public bool canCatch;

    public void Start()
    {
        anim = GetComponent<Animator>();
        canCatch = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Monstre" && canCatch == true)
        {
            Rigidbody body = other.gameObject.GetComponent<Rigidbody>();
            NavMeshAgent nav = other.gameObject.GetComponent<NavMeshAgent>();
            StartCoroutine(TrapActive(body, nav));
        }
    }

    public IEnumerator TrapActive(Rigidbody body, NavMeshAgent nav)
    {
        anim.SetBool("isEnable", true);
        body.constraints = RigidbodyConstraints.FreezeAll;
        nav.speed = 0;

        yield return new WaitForSeconds(5);
        anim.SetBool("isEnable", false);
        anim.SetTrigger("isDisabled");
        body.constraints = RigidbodyConstraints.None;
        nav.speed = 2;
        canCatch = false;
    }

}
