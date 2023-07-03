using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorSkeletons : MonoBehaviour
{

    public GameObject skeletonsPrefab;
    public Transform[] generadorPuntos;
    public float velocidadGeneracion;
    // Start is called before the first frame update
    void Start()
    {
        // cada segundo se repite la funcion generarSkeleton
        InvokeRepeating("generarSkeleton", velocidadGeneracion, 1f);
    }


    // Update is called once per frame
    private void generarSkeleton()
    {
        //Instantiate(skeletonsPrefab, generadorPuntos[Random.Range(0, generadorPuntos.Length)].position, Quaternion.identity);

        // generar un nuevo prefab de skeleton
        GameObject newSkeleton = Instantiate(skeletonsPrefab, generadorPuntos[Random.Range(0, generadorPuntos.Length)].position, Quaternion.identity);

        //destruir newSkeleton en 10 segundos
        Destroy(newSkeleton, 10f);
    }
}
