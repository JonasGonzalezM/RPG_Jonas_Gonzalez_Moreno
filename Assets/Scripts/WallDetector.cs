using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class WallDetector : MonoBehaviour
{

    [SerializeField] private float tiempoDifuminado = 1f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstaculo"))
        {
           Material materialPared= other.GetComponent<MeshRenderer>().material;

           Color transparente = new Color(materialPared.color.r,materialPared.color.g,materialPared.color.b, 0f);

            materialPared.DOColor(transparente, tiempoDifuminado);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstaculo"))
        {
            Material materialPared = other.GetComponent<MeshRenderer>().material;

            Color opaco = new Color(materialPared.color.r, materialPared.color.g, materialPared.color.b, 1f);
            materialPared.DOColor(opaco,tiempoDifuminado);

        }
    }
}
