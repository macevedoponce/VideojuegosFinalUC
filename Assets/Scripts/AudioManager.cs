using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] sounds;

    private AudioSource audioController;

    private void Awake() {
        audioController = GetComponent<AudioSource>();
    }

    public void ChooseAudio(int indice, float volume){
        audioController.PlayOneShot(sounds[indice], volume);
    }
}
