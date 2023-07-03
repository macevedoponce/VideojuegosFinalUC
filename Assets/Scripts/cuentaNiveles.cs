using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cuentaNiveles : MonoBehaviour
{
    public int niveles;
    public Text numNivelText;

    public static cuentaNiveles instance;

    private void Start()
    {
        numNivelText.text = 1+"";
    }
    public void Nivel(int serviciosRecogidas)
    {
        niveles += serviciosRecogidas;
        numNivelText.text = niveles.ToString();
    }
    private void Awake()
    {   //singleton
        if (instance == null)
        {
            instance = this;
        }
    }
}
