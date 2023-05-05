using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorArma : MonoBehaviour
{
    [SerializeField] int armaActual = 0;
    // Start is called before the first frame update
    void Start()
    {
        SetArmaActiva();
    }

    void SetArmaActiva()
    {
        int indiceArma = 0;
        foreach( Transform arma in transform)
        {
            if(indiceArma == armaActual)
            {
                arma.gameObject.SetActive(true);
            }
            else
            {
                arma.gameObject.SetActive(false);
            }
            indiceArma++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int armaAnterior = armaActual;

        ProcessKeyInput();
       // ProcessScrollWheel();
        if(armaAnterior != armaActual)
        {
            SetArmaActiva();
        }
    }

    private void ProcessKeyInput(){
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            armaActual = 0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            armaActual = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            armaActual = 2;
        }
    }
}
