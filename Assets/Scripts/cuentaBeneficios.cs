using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cuentaBeneficios : MonoBehaviour
{
    public float beneficios;
    public Text numBeneficioText;

    public static cuentaBeneficios instance;
    public void Beneficio(float beneficiosRecogidos)
    {
        beneficios += beneficiosRecogidos;
        numBeneficioText.text = beneficios.ToString();
    }
    private void Awake()
    {   //singleton
        if (instance == null)
        {
            instance = this;
        }
    }
}
