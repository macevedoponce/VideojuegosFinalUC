using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beneficios : MonoBehaviour
{
    public float beneficioOtorgar;
    private AudioManager soundManager;

    void Start()
    {
        soundManager = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        //otorgar monedas en el GameManager
        soundManager.ChooseAudio(1, 1f);
        cuentaBeneficios.instance.Beneficio(beneficioOtorgar);
        Destroy(gameObject);
    }
}
