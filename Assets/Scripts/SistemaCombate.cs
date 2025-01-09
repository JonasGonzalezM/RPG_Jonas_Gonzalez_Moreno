using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] private Enemigo main;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float velocidadCombate = 3f;

    // agent.velocidad supongo para aumentarla
    // Start is called before the first frame update
    private void Awake()
    {
        main.Combate = this;
        
    }
    //OnEnable : Se ejecuta cuando se activa el Script
    //Se puede ejecutar VARIAS VECES.
    private void OnEnable()
    {
        agent.speed = velocidadCombate;
        
    }

    private void Update()
    {
        //Voy persiguiendo al target en todo momento (calculando su posicion) usando Update porque
        //el Fixed Update da problemas a la hora del movimiento
        agent.SetDestination(main.Target.position);
    }


}
