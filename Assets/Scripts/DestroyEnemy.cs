using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public int saludActual = 2;
    private AudioManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    public void Damage(int cantidadDamage)
    {
        saludActual -= cantidadDamage;
        if (saludActual <= 0)
        {
            soundManager.ChooseAudio(3, 0.5f);
            gameObject.SetActive(false);
        }
    }
}
