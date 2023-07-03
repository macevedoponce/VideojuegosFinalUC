using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MisionBeneficios : MonoBehaviour
{
    public int numObjectivos;
    public TextMeshProUGUI textoMision;
    public GameObject btnMision;
    public GameObject infoBeneficio;
    // Start is called before the first frame update
    void Start()
    {
        numObjectivos = GameObject.FindGameObjectsWithTag("Beneficio").Length;
        textoMision.text = "Encuentra los beneficios UC" + "\n Restantes: " + numObjectivos;
        infoBeneficio.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Beneficio")
        {
            infoBeneficio.SetActive(true);
            Destroy(col.transform.parent.gameObject);
            numObjectivos--;
            textoMision.text = "Encuentra los beneficios UC" + "\n Restantes: " + numObjectivos;
            if(numObjectivos <= 0)
            {
                textoMision.text = "Misión completada";
                btnMision.SetActive(true);
                cuentaNiveles.instance.Nivel(1);
            }
        }
        
    }
}
