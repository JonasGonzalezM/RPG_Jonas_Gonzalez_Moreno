using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaPatrulla : MonoBehaviour
{
    [SerializeField] private Transform ruta;

    private List<Vector3> listadoPuntos=new List<Vector3>();// Lista es una Longitud y es Variable
    //Pregunta de examen

    [SerializeField] private NavMeshAgent agent;

    private int indiceActual = -1; //marca el punto al cual debo ir

    private Vector3 destinoActual; //Marca el destino al cual debo ir.


    //Diferencia con array
    //private Transform[] array = new Transform[50]; // Array es una longitud FIJA

    private void Awake() //Funciona antes del Start. Se puede decir que tiene prioridad al Start
    {

        agent = GetComponent<NavMeshAgent>();

        foreach (Transform punto in ruta)
        {
            //añado todosl los puntos de ruta al listado
            listadoPuntos.Add(punto.position);
            //Debug.Log(punto.name);

        }

    }



    void Start()
    {

        StartCoroutine(PatrullarYEsperar());
    }

    private IEnumerator PatrullarYEsperar() // El IEnumerator es una Corrutina
    {
        //Por siempre.
        while(true)
        {

            CalcularDestino(); //Tendre que calcular el nuevo destino
            //Ir a destino 
            agent.SetDestination(destinoActual);
            yield return new WaitUntil( ()=> agent.remainingDistance<=0); //Expresion Lambda, es un metodo anónimo
            //Te pide que metas una funcion que tenga un bool y que hasta que el agente llegue al punto no devolverá un true
            //yield return new WaitUntil( ()=> agent.remainingDistance<=0);


            //Espera una vez llegado al punto entre 0.25 y 3 segundos
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.25f, 3f));
        }



    }

    private bool CalcularDistanciaRestante()
    {
        if (agent.remainingDistance <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void CalcularDestino()
    {
        indiceActual++;
        // Si nos hemos quedado sin puntos....
        if (indiceActual >= listadoPuntos.Count)
        {
            indiceActual = 0;
        }

        //Mi destino es dentro del listado de puntos aquel con el nuevo indice calculado.
        destinoActual = listadoPuntos[indiceActual];
    }


    //Posible pregunta de examen y esto no iniciaria porque no se ha iniciado la Corrutina.
    // Si se ejecuta explota porque no hay un solo yield 
}
