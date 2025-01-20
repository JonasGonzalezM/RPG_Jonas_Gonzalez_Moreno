using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMinimapa : MonoBehaviour
{
    [SerializeField] private Player player;
    
    
    private Vector3 distanciaAPlayer;

    // Start is called before the first frame update
    void Start()
    {

        // calculo la distancia inicial que hay entre el player y la camara
        distanciaAPlayer = transform.position- player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //mantiene constante al player y su ubicacion
        transform.position = player.transform.position + distanciaAPlayer;
    }
}
