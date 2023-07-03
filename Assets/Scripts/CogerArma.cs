using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerArma : MonoBehaviour
{
    public BoxCollider espadaBoxCol;
    public BoxCollider[] puñosBoxCol;
    


    public GameObject[] armas;

    public PlayerController playerController;
    void Start()
    {
        DesactivarColliderPuños();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DesactivarArmas();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            ActivarArma(0);
            playerController.numArma = 1;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            ActivarArma(1);
            playerController.numArma = 2;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            ActivarArma(2);
            playerController.numArma = 3;
        }
    }

    public void ActivarArma(int numero)
    {
        for (int i = 0; i < armas.Length; i++)
        {
            armas[i].SetActive(false);
        }

        armas[numero].SetActive(true);
        playerController.conArma = true;
    }

    public void DesactivarArmas()
    {
        for (int i = 0; i < armas.Length; i++)
        {
            armas[i].SetActive(false);
        }
        playerController.conArma = false;
    }

    public void ActivarColliderPuños()
    {
        for(int i = 0; i < puñosBoxCol.Length; i++)
        {
            if (!playerController.conArma)
            {
                if (puñosBoxCol[i] != null)
                {
                    puñosBoxCol[i].enabled = true;
                }
            }
            else
            {
                espadaBoxCol.enabled = true;
            }
        }
    }

    public void DesactivarColliderPuños()
    {
        for (int i = 0; i < puñosBoxCol.Length; i++)
        {
            if (puñosBoxCol[i] != null)
            {
                puñosBoxCol[i].enabled = false;
            }
        }
        espadaBoxCol.enabled = false;
    }
}
