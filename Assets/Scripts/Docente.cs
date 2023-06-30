using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Docente : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;

    private bool isWalking = false;
    private float walkTimer = 0f;
    private float walkDuration = 5f;

    void Start()
    {

    }

    public void Comportamiento_Docente()
    {
        cronometro += Time.deltaTime;
        if (cronometro >= 2)
        {
            rutina = Random.Range(0, 2);
            cronometro = 0;
        }
        switch (rutina)
        {
            case 0:
                ani.SetBool("walk", false);
                break;
            case 1:
                grado = Random.Range(0, 360);
                angulo = Quaternion.Euler(0, grado, 0);
                rutina++;
                break;
            case 2:
                if (!isWalking)
                {
                    isWalking = true;
                    walkTimer = 0f;
                }
                walkTimer += Time.deltaTime;
                if (walkTimer <= walkDuration)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * Time.deltaTime);
                    ani.SetBool("walk", true);
                }
                else
                {
                    isWalking = false;
                    ani.SetBool("walk", false);
                }
                break;
        }
    }

    void Update()
    {
        Comportamiento_Docente();
    }
}
