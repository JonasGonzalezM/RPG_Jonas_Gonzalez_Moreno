using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (menuName = "Misión")]
public class MisionSO : ScriptableObject
{
    public string ordenInicial;//Mensaje inicial
    public string ordenFinal;//Mensaje victoria
    public bool tieneRepeticion;
    public int totalRepeticiones;//Veces que tengo que repetir ese paso (0/8)
    public int indiceMision;//indice unico que representa a cada mision


    [NonSerialized] //para que el campo pueda resetear entre partidas
    public int repeticionActual = 0; // (3/8  (4/8) ....
}
