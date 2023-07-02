using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarMoneda : MonoBehaviour
{
    [Range(1, 90)]
	public float velocidad = 45;

	//Direccion del movimiento
	private Vector3 direccion = Vector3.up;

	//Límites de rotación
	private int limiteSuperior = 360;
	private int limiteInferior = 90;

	void Update()
	{

		//Si alcanza el límite superior, dirección bajada
		if (transform.rotation.eulerAngles.y >= limiteSuperior)
		{
			direccion = Vector3.down;
		}

		//Si alcanza el límite inferior, dirección subida
		if (transform.rotation.eulerAngles.y <= limiteInferior)
		{
			direccion = Vector3.up;
		}

		//Rota la plataforma en cada frame a la velocidad y en la dirección indicadas
		transform.Rotate(direccion * Time.deltaTime * velocidad);

	}
}
