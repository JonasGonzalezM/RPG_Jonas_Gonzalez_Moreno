using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetaDeMuerte : MonoBehaviour,IInteractuable
{

    private Outline outline;

    [SerializeField] private MisionSO mision;

    [SerializeField] private EventManagerSO eventManager;



    // Start is called before the first frame update
    private void Awake()
    {
        outline = GetComponent<Outline>();
    }
    public void Interactuar()
    {
        mision.repeticionActual++; //Aumentamos en uno la repeticion de esta misión

        //Todavia quedan setas por recoger
        if ((mision.repeticionActual < mision.totalRepeticiones))
        {
            eventManager.ActualizarMision(mision);
        }
        else //Ya hemos terminado de recoger todas las setas
        {
            eventManager.TerminarMision(mision);
        }
        Destroy(gameObject);
        
    }

    // Update is called once per frame
    private void OnMouseEnter() => outline.enabled = true;

    private void OnMouseExit()
    {
        outline.enabled = false;
    }

}
