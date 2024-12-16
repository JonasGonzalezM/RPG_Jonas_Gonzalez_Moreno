using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private DialogoSO miDialogo;
    [SerializeField] private float duracionRotacion;
    [SerializeField] private Transform cameraPoint; //punto que referencia la camara?¿ 
    public void Interactuar(Transform interactuador)
    {
        //poco a poco voy rotando hacia el interactuador y CUANDO TERMINE de rotarme..... se inicia la interaccion.
        Debug.Log("Hola!");
        transform.DOLookAt(interactuador.position,duracionRotacion,AxisConstraint.Y).OnComplete(IniciarInteraccion);
    }


    private void IniciarInteraccion()
    {
        Debug.Log("Se inicia interaccion");
        SistemaDialogo.trono.IniciarDialogo(miDialogo, cameraPoint);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
