using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float speedRotacion = 200.0f;
    public Animator anim;
    private float mouseX, mouseY;

    public Rigidbody rb;
    public float fuerzaSalto = 8.0f;
    public bool puedeSaltar;

    public bool estoyAtacando;
    public bool avanzoSolo;
    public float impulsoDeGolpe = 5f;

    //correr
    public float velCorrer;

    //velocidad del mouse
    public float mouseSensitivity = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        puedeSaltar = false;
        anim = GetComponent<Animator>();

        // Mostrar y desbloquear el cursor del mouse
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void FixedUpdate()
    {
        if (!estoyAtacando) //si no ataco me puedo mover
        {
            float rotationY = transform.localEulerAngles.y + mouseX * Time.deltaTime * speedRotacion * mouseSensitivity;
            transform.localEulerAngles = new Vector3(0, rotationY, 0); //rotación horizontal

            // Movimiento vertical (adelante/atrás)
            Vector3 movement = transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime;
            rb.MovePosition(rb.position + movement); //desplazamiento
            // Movimiento horizontal (izquierda/derecha)
            movement = transform.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            rb.MovePosition(rb.position + movement); //desplazamiento
        }

        if (avanzoSolo)
        {
            rb.velocity = transform.forward * impulsoDeGolpe;
        }
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        // Ajustar la velocidad del mouse
        mouseSensitivity = Mathf.Clamp(mouseSensitivity + Input.GetAxis("Mouse ScrollWheel"), 1.0f, 10.0f);

        //correr
        if (Input.GetKey(KeyCode.LeftShift) && puedeSaltar && !estoyAtacando)
        {
            speed = velCorrer;
            anim.SetBool("correr", (Input.GetAxis("Vertical") > 0));
        }
        else
        {
            speed = 5.0f;
            anim.SetBool("correr", false);
        }

        //btn atacck
        if (Input.GetKeyDown(KeyCode.Return) && puedeSaltar && !estoyAtacando)
        {
            anim.SetTrigger("golpeo");
            estoyAtacando = true;
        }

        if (Input.GetKeyDown(KeyCode.F1) && puedeSaltar && !estoyAtacando)
        {
            anim.SetTrigger("golpeoCombo");
            estoyAtacando = true;
        }

        anim.SetFloat("VelX", Input.GetAxis("Horizontal"));
        anim.SetFloat("VelY", Input.GetAxis("Vertical"));

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
        else
        {
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
