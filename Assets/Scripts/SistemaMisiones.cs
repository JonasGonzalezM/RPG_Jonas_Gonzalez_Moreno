using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaMisiones : MonoBehaviour
{
    [SerializeField]
    private EventManagerSO eventManager;

    [SerializeField] private ToggleMision[] togglesMision;
    //Start is called before the first frame update
    private void OnEnable()
    {
        eventManager.OnNuevaMision += EncenderToggleMision;
        //eventManager.OnActualizarMision+= 
    }

    private void EncenderToggleMision(MisionSO mision)
    {

    }

    private void ActualizarToggleMision(MisionSO mision)
    {
        togglesMision[mision.indiceMision].Text.text = mision.ordenInicial;
        togglesMision[mision.indiceMision].Text.text += "(" + mision.repeticionActual + "/" + mision.totalRepeticiones + ")";
    }
}
