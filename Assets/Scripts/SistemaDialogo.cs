using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{

    //PATRON SINGLE-TON
    //1. SOLO EXISTE UNA INSTANCIA DE  SistemaDialogo
    //2. Es accesible desde cualqiuer punto del programa


    public static SistemaDialogo trono;


    
    // Awake se ejecuta ANTES del Start() independientemente de que el gameObject esté activo o no.
    void Awake()
    {
        //Si el trono está libre....
        if(trono == null)
        {
            //Si el trono está libre, y entonces SistemaDialogo SOY YO (this)...
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
