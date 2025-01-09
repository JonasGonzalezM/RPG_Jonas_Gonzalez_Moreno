using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private SistemaPatrulla patrulla;
    private SistemaCombate combate;
    private Transform target;

    public SistemaPatrulla Patrulla { get => patrulla; set => patrulla = value; }
    public SistemaCombate Combate { get => combate; set => combate = value; }
    public Transform Target { get => target; set => target = value; }

    internal void ActivarCombate( Transform target)
    {
        combate.enabled = true;  // activamos combate
        patrulla.enabled = false; // desactivamos la patrulla
        this.target = target; // definimos target
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
