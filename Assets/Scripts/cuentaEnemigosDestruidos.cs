using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cuentaEnemigosDestruidos : MonoBehaviour
{
    public int enemigosDestruidos;
    public Text numEnemigosDestruidos;

    public static cuentaEnemigosDestruidos instance;

    public void EnemigosDestruidos(int enemigosRecogidos)
    {
        enemigosDestruidos += enemigosRecogidos;
        numEnemigosDestruidos.text = enemigosDestruidos.ToString();
    }
    private void Awake()
    {   //singleton
        if (instance == null)
        {
            instance = this;
        }
    }
}
