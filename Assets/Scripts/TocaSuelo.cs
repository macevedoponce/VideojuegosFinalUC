using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TocaSuelo : MonoBehaviour
{
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        playerController.puedeSaltar = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerController.puedeSaltar = false;
    }
}
