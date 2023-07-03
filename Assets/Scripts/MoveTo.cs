using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    // Start is called before the first frame update
    //public Transform meta;
    private GameObject player;
    private NavMeshAgent agente;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        this.agente = gameObject.GetComponent<NavMeshAgent>();

        if (player != null)
        {
            SetDestination(player.transform.position);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            SetDestination(player.transform.position);
        }
    }

    private void SetDestination(Vector3 position)
    {
        agente.SetDestination(position);
    }
}
