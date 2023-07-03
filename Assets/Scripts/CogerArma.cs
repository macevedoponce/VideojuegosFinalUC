using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerArma : MonoBehaviour
{
    public BoxCollider espadaBoxCol;
    public BoxCollider[] pu�osBoxCol;
    


    public GameObject[] armas;

    public PlayerController playerController;
    void Start()
    {
        DesactivarColliderPu�os();
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

    public void ActivarColliderPu�os()
    {
        for(int i = 0; i < pu�osBoxCol.Length; i++)
        {
            if (!playerController.conArma)
            {
                if (pu�osBoxCol[i] != null)
                {
                    pu�osBoxCol[i].enabled = true;
                }
            }
            else
            {
                espadaBoxCol.enabled = true;
            }
        }
    }

    public void DesactivarColliderPu�os()
    {
        for (int i = 0; i < pu�osBoxCol.Length; i++)
        {
            if (pu�osBoxCol[i] != null)
            {
                pu�osBoxCol[i].enabled = false;
            }
        }
        espadaBoxCol.enabled = false;
    }
}
