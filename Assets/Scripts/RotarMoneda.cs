using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarMoneda : MonoBehaviour
{
    [Range(1, 90)]
	public float velocidad = 45;

	//Direccion del movimiento
	private Vector3 direccion = Vector3.up;

	//L�mites de rotaci�n
	private int limiteSuperior = 360;
	private int limiteInferior = 90;

	void Update()
	{

		//Si alcanza el l�mite superior, direcci�n bajada
		if (transform.rotation.eulerAngles.y >= limiteSuperior)
		{
			direccion = Vector3.down;
		}

		//Si alcanza el l�mite inferior, direcci�n subida
		if (transform.rotation.eulerAngles.y <= limiteInferior)
		{
			direccion = Vector3.up;
		}

		//Rota la plataforma en cada frame a la velocidad y en la direcci�n indicadas
		transform.Rotate(direccion * Time.deltaTime * velocidad);

	}
}
