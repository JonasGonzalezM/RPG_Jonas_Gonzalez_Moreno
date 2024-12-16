using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaPatrulla : MonoBehaviour
{
    [SerializeField] private Transform ruta;

    private List<Transform> listadoPuntos=new List<Transform>();// Lista es una Longitud y es Variable
    //Pregunta de examen

    //Diferencia con array
    //private Transform[] array = new Transform[50]; // Array es una longitud FIJA

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform punto in ruta)
        {

            //Debug.Log(punto.name);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
