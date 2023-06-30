using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float speedRotacion = 200.0f;
    private Animator anim;
    public float x, y;

    public Rigidbody rb;
    public float fuerzaSalto = 8.0f;
    public bool puedeSaltar;

    public bool estoyAtacando;
    public bool avanzoSolo;
    public float impulsoDeGolpe = 5f;

    //Audios


    //correr
    public float velCorrer;

    // Start is called before the first frame update
    void Start()
    {
        puedeSaltar = false;
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        if (!estoyAtacando) //si no ataco me puedo mover
        {
            transform.Rotate(0, x * Time.deltaTime * speedRotacion, 0); //rota
            transform.Translate(0, 0, y * Time.deltaTime * speed);//desplazamiento
        }

        
        if(avanzoSolo)
        {
            rb.velocity = transform.forward * impulsoDeGolpe;
        }
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        //correr
        if(Input.GetKey(KeyCode.LeftShift) && puedeSaltar && !estoyAtacando)
        {
            speed = velCorrer;
            if(y > 0)
            {
                anim.SetBool("correr", true);
            }
            else
            {
                anim.SetBool("correr", false);
            }
        }
        else
        {
            speed = 5.0f;
            anim.SetBool("correr", false);
        }

        //btn atacck
        if(Input.GetKeyDown(KeyCode.Return) && puedeSaltar && !estoyAtacando)
        {
            anim.SetTrigger("golpeo");
            estoyAtacando = true;
        }

        if (Input.GetKeyDown(KeyCode.F1) && puedeSaltar && !estoyAtacando)
        {
            anim.SetTrigger("golpeoCombo");
            estoyAtacando = true;
        }

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        if (puedeSaltar)
        {
            if (!estoyAtacando)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetBool("jump", true);
                    rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
                }
                anim.SetBool("tocoSuelo", true);
            }
            
        }
        else {
            personajeEnCaida();
        }
    }

    public void personajeEnCaida()
    {
        anim.SetBool("tocoSuelo", false);
        anim.SetBool("jump", false);
    }

    public void DejeDeGolpear()
    {
        estoyAtacando = false;
    }

    public void AvanzoSolo()
    {
        avanzoSolo = true;
    }

    public void DejoDeAvanzar()
    {
        avanzoSolo = false;
    }
}
