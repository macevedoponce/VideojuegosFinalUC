using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCajas : MonoBehaviour
{
    public int saludActual = 3;
    // Start is called before the first frame update
    public void Damage (int cantidadDamage)
    {
        saludActual -= cantidadDamage;
        if(saludActual <=0)
        {
            gameObject.SetActive(false);
        }
    }
}
