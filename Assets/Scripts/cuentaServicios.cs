using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cuentaServicios : MonoBehaviour
{
    public float servicios;
    public Text numServiciosText;

    public static cuentaServicios instance;
    public void Servicio(float serviciosRecogidas)
    {
        servicios += serviciosRecogidas;
        numServiciosText.text = servicios.ToString();
        //CambiarNivel.instance.CambNivel(monedas);
    }
    private void Awake()
    {   //singleton
        if (instance == null)
        {
            instance = this;
        }
    }
}
