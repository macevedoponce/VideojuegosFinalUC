using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCajas : MonoBehaviour
{
    public int saludActual = 3;
    private AudioManager soundManager;
    // Start is called before the first frame update

    void Start()
    {
        soundManager = FindObjectOfType<AudioManager>();
    }

    public void Damage (int cantidadDamage)
    {
        saludActual -= cantidadDamage;
        if(saludActual <=0)
        {
            soundManager.ChooseAudio(2, 0.5f);
            gameObject.SetActive(false);
        }
    }
}
