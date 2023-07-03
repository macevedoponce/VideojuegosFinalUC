using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarArmaPlayer : MonoBehaviour
{
    public CogerArma cogerArma;
    public int numeroArma;
    public PlayerController playerController;
    void Start()
    {
        cogerArma = GameObject.FindGameObjectWithTag("Player").GetComponent<CogerArma>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            cogerArma.ActivarArma(numeroArma);
            playerController.numArma = numeroArma+1;
            Destroy(gameObject);
        }
    }
}
