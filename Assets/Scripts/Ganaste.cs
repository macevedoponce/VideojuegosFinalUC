using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ganaste : MonoBehaviour
{
    public GameObject ganaste;
    private AudioManager soundManager;

    void Start()
    {
        soundManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            soundManager.ChooseAudio(4, 1f);
            ganaste.SetActive(true);
            Debug.Log("Ganaste el juego");
        }
        
    }
    
    
}
