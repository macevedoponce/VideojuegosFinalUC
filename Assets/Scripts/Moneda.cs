using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    public float monedasOtorgar;
    private AudioManager soundManager;

    void Start ()
    {
        soundManager = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        //otorgar monedas en el GameManager
        soundManager.ChooseAudio(1, 1f);
        CuentaMonedas.instance.Money(monedasOtorgar);
        Destroy(gameObject);
    }
}
