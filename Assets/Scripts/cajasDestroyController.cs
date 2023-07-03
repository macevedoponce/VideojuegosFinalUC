using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cajasDestroyController : MonoBehaviour
{
    public int hp;
    public int da�oEspada;
    public int da�uPu�o;
    public Animator anim;

    void Start()
    {

    }


    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "espadaImpacto")
        {
            if (anim != null)
            {
                anim.Play("KidneyHitEnemy");
            }
            hp -= da�oEspada;
        }

        if (other.gameObject.tag == "golpeImpacto")
        {
            if (anim != null)
            {
                anim.Play("KidneyHitEnemy");
            }
            hp -= da�uPu�o;
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
