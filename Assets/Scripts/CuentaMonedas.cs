using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CuentaMonedas : MonoBehaviour
{
    public float monedas;
    public Text banckText;

    public static CuentaMonedas instance;
    public void Money(float monedasRecogidas)
    {
        monedas += monedasRecogidas;
        banckText.text = monedas.ToString();
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
