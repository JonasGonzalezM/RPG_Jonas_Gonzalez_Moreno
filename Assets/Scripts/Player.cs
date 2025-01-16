using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;

    //Almaceno el ultimo transform que clicke con el raton
    private Transform ultimoClick;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
   // El FixedUpdate puede dar caso a misclicks para esto mejor un Update
    void Update()
    {
        if (Time.timeScale == 1)
        {
          
            Movimiento();
            
        }
        ComprobarInteraccion();
    }


    private void Movimiento()
    {
        // Si clicko con el mouse izq
        if (Input.GetMouseButtonDown(0))
        {
            // creo un rayo desde la camara a la posicion del raton
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            //y si ese rayo impacta en algo...
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                //Le decimos al agente (nosotros) que tiene como destino en el punto de impacto
                agent.SetDestination(hitInfo.point);

                //Actualizo el ultimoHit con el transform que acavo de clickar.
                ultimoClick = hitInfo.transform;

            }

        }
    }
   
    
    
    
    
    
    
    private void ComprobarInteraccion()
    {
       //Si existe un interactuable al cual clicke y lleva consigo el script NPC...
        if(ultimoClick!=null && ultimoClick.TryGetComponent(out NPC npc))
        {
            
            //actualizo la distacia de parada para no besar la boca del NPC
            agent.stoppingDistance = 2f;

            //Mira a ver si hemos llegado a dicho destino..
            // lo vimos con el tema de las animaciones de Pedro el zombi del anterior juego..
            //sirve para evitar que el valor inicial sea 0.
            if(!agent.pathPending&& agent.remainingDistance<= agent.stoppingDistance)
            {
                //Y por lo tanto, interactúo con el NPC o enemigos.
                npc.Interactuar(transform);

                //Me olvido de cual fue el último click, porque sólo quiero interactuar UNA VEZ
                ultimoClick=null;
            }
        }
        //Si no es un NPC, si no que es un click en el suelo....
        else if (ultimoClick)
        {
            //reseteo el stoppingDistance original
            agent.stoppingDistance = 0f;
        }
    }



    

    public void HacerDanho(float danhoAtaque)
    {
        Debug.Log("me has hecho" + danhoAtaque);
    }
}
