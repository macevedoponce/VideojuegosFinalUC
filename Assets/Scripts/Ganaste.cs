using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ganaste : MonoBehaviour
{
    public GameObject ganaste;

    private void OnEnable() {
        VidaFPS.OnPlayerWin += EnableGanaste;
    }

    private void OnDisable() {
        VidaFPS.OnPlayerWin -= EnableGanaste;
    }

    public void EnableGanaste(){
        ganaste.SetActive(true);
    }
}
