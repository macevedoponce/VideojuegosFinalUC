using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaBeneficios : MonoBehaviour
{
    public LogicaDocente logicaDocente;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        logicaDocente.numObjetivos--;
        logicaDocente.textoMision.text = "Encuentra los beneficios UC" + "\n Restantes: " + logicaDocente.numObjetivos;

        if(logicaDocente.numObjetivos <= 0)
        {
            logicaDocente.textoMision.text = "Completaste la misión";
            logicaDocente.btnMision.SetActive(true);
        }

        transform.parent.gameObject.SetActive(false);
    }
}
