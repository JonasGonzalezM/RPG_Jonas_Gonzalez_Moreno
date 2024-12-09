using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{

    //PATRON SINGLE-TON
    //1. SOLO EXISTE UNA INSTANCIA DE  SistemaDialogo
    //2. Es accesible desde cualqiuer punto del programa


    public static SistemaDialogo trono;


    
    // Awake se ejecuta ANTES del Start() independientemente de que el gameObject est� activo o no.
    void Awake()
    {
        //Si el trono est� libre....
        if(trono == null)
        {
            //Si el trono est� libre, y entonces SistemaDialogo SOY YO (this)...
            trono = this;
            
        }
        else
        {
            // Me han quitado el trono, por lo tanto, me mato (soy un falso rey)
            Destroy(this.gameObject);
        }
    }

    public void IniciarDialogo(DialogoSO dialogo)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
