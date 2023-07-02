using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;

    private void OnEnable() {
        VidaFPS.OnPlayerDeath += EnableGameOver;
    }

    private void OnDisable() {
        VidaFPS.OnPlayerDeath -= EnableGameOver;
    }

    public void EnableGameOver(){
        gameOver.SetActive(true);
    }

}
