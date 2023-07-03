using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Servicios : MonoBehaviour
{
    public float serviciosOtorgar;
    private AudioManager soundManager;

    void Start()
    {
        soundManager = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        //otorgar monedas en el GameManager
        soundManager.ChooseAudio(1, 1f);
        cuentaServicios.instance.Servicio(serviciosOtorgar);
        Destroy(gameObject);
    }
}
