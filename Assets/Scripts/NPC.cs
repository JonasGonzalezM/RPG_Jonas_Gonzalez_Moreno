using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractuable
{
    [SerializeField] EventManagerSO eventManager;
    [SerializeField] private MisionSO miMision;
    //[SerializeField] private DialogoSO miDialogo;
    [SerializeField] private DialogoSO dialogo1;
    [SerializeField] private DialogoSO dialogo2;
    [SerializeField] private float duracionRotacion;
    [SerializeField] private float lookAtDuration;
    [SerializeField] private Transform cameraPoint; //punto que referencia la camara?¿ 

    private DialogoSO dialogoActual;


    private void Awake()
    {
        dialogoActual = dialogo1;
    }


    private void OnEnable()
    {
        eventManager.OnTerminarMision += CambiarDialogo;
    }

    private void CambiarDialogo(MisionSO misionTerminada)
    {
        if (miMision == misionTerminada)
        {
            dialogoActual = dialogo2;
        }
    }
    public void Interactuar(Transform interactuador)
    {
        //poco a poco voy rotando hacia el interactuador y CUANDO TERMINE de rotarme..... se inicia la interaccion.
        //Debug.Log("Hola!");
        transform.DOLookAt(interactuador.position,duracionRotacion,AxisConstraint.Y).OnComplete(IniciarInteraccion);
    }

    public void Interactuar()
    {
        
        //transform.DOLookAt(interactor.position,)
    }

    private void IniciarInteraccion()
    {
        //Debug.Log("Se inicia interaccion");
        SistemaDialogo.trono.IniciarDialogo(dialogoActual, cameraPoint);
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
