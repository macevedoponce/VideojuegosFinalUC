using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorBalas : MonoBehaviour
{
    public float municion;
    public Text muniText;

    public static ContadorBalas instance;

    private void Start() {
        muniText.text =  municion.ToString();
    }

    public void MunicionDar(float municionRecogidas){
        municion += municionRecogidas;
        muniText.text = municion.ToString();
    }

    public void MunicionQuitar(){
        municion -= 1;
        muniText.text = municion.ToString();
    }

    private void Awake() {
        if(instance == null){instance = this;}
    }
}
