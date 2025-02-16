using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaMisiones : MonoBehaviour
{
    [SerializeField] private EventManagerSO eventManager;

    [SerializeField] private ToggleMision[] toggleMision; // coleccion de toggles


    private void OnEnable()
    {
        // Me suscribo al evento y lo vinculo con el metodo 
        eventManager.OnNuevaMision += EncenderToggleMision;
        eventManager.OnActualizarMision += ActualizarToggleMision;
        eventManager.OnTerminarMision += TerminarTogglelMision;
    }

    private void EncenderToggleMision(MisionSO mision)
    {
        //Lleno el texto con el contenido de la mision 
        toggleMision[mision.indiceMision].textoMision.text = mision.ordenInicial; //(0/3)

        // Y si tiene repetcion..
        if (mision.tieneRepeticion)
        {
            toggleMision[mision.indiceMision].textoMision.text += "(" + mision.repeticionActual + "/" + mision.totalRepeticiones + ")";
        }

        toggleMision[mision.indiceMision].gameObject.SetActive(true); // Enciendo el toggle para que se vea en pantalla.
    }
    private void ActualizarToggleMision(MisionSO mision)
    {
        toggleMision[mision.indiceMision].textoMision.text = mision.ordenInicial;
        toggleMision[mision.indiceMision].textoMision.text += "(" + mision.repeticionActual + "/" + mision.totalRepeticiones + ")";
    }

    private void TerminarTogglelMision(MisionSO mision)
    {
        toggleMision[mision.indiceMision].ToggleVisual.isOn = true;// Al terminar la mision "Chekeamos"el toggle.
        toggleMision[mision.indiceMision].textoMision.text = mision.ordenFinal; // ponemos el texto victoria.
    }
}
