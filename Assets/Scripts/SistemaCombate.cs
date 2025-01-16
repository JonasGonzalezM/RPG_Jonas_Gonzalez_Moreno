using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] private Enemigo main;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float velocidadCombate = 3f;
    [SerializeField] private float distancia;
    [SerializeField] private float danhoAtaque;
    [SerializeField] private Animator anim;

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
        agent.stoppingDistance = distancia;
        
    }

    private void Update()
    {

        if(main.Target != null&& agent.CalculatePath(main.Target.position, new NavMeshPath()))
        {
            //procuraremos que siempre se enfoque al player

            EnfocarObjetivo();


            agent.SetDestination(main.Target.position);


            if (!agent.pathPending && agent.remainingDistance <= distancia)
            {
                //agent.isStopped = true;
                anim.SetBool("attacking", true);

            }

        }
        else
        {
            main.ActivarPatrulla();
        }
        //Voy persiguiendo al target en todo momento (calculando su posicion) usando Update porque
        //el Fixed Update da problemas a la hora del movimiento
    }

    private void EnfocarObjetivo()
    {
        //Calcula la direccion al objetivo
        Vector3 direccionATarget = (main.Target.transform.position - agent.transform.position).normalized;
        // evito que roto de cabeza hacia adelante
        direccionATarget.y=0;
        //transformo una dirreccion en una rotacion 
        Quaternion rotacionATarget = Quaternion.LookRotation(direccionATarget);
        //roto  hacia el target
        transform.rotation = rotacionATarget;


    }

    #region Ejecutados por evento de animación
    private void Atacar()
    {
        main.Target.GetComponent<Player>().HacerDanho(danhoAtaque);
    }

    private void FinAnimacionAtaque()
    {
        anim.SetBool("atttacking",false);
    }
    #endregion
}
