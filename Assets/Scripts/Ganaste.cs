using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ganaste : MonoBehaviour
{
    public GameObject ganaste;
    private AudioManager soundManager;
    private bool isPaused = false;
    public string sceneName; // Nombre de la escena a la que quieres cambiar

    void Start()
    {
        soundManager = FindObjectOfType<AudioManager>();
    }

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isPaused)
        {
            ChangeScene();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(sceneName); // Carga la escena con el nombre especificado
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PauseGame();
            soundManager.ChooseAudio(4, 1f);
            ganaste.SetActive(true);
            Debug.Log("Ganaste el juego");
           
        }
        
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // Pausa el juego estableciendo la escala de tiempo en 0
        isPaused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f; // Reanuda el juego estableciendo la escala de tiempo en 1
        isPaused = false;
        // Aquí puedes agregar cualquier otro código que desees ejecutar al reanudar el juego
    }


}
