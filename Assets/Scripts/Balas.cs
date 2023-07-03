using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balas : MonoBehaviour
{
    public float municionOtorgar;
    private AudioManager soundManager;

    private void Start() {
        soundManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter(Collider other) {
        soundManager.ChooseAudio(2, 0.5f);
        ContadorBalas.instance.MunicionDar(municionOtorgar);

        Destroy(gameObject);
    }
}
