using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{
    [SerializeField] public EventManagerSO eventManager;
    [SerializeField] private GameObject marcoDialogo;
    [SerializeField] private TMP_Text textoDialogo;
    [SerializeField] private Transform npcCamera; //Camara compartida por todos los NPCs.
    //PATRON SINGLE-TON
    //1. SOLO EXISTE UNA INSTANCIA DE  SistemaDialogo
    //2. Es accesible desde cualqiuer punto del programa


    private bool escribiendo;
    private int indiceFraseActual = 0;

    public static SistemaDialogo trono;
    private DialogoSO dialogoActual;


    
    // Awake se ejecuta ANTES del Start() independientemente de que el gameObject esté activo o no.
    void Awake()
    {
        //Si el trono está libre....
        if(trono == null)
        {
            //Si el trono está libre, y entonces SistemaDialogo SOY YO (this)...
            trono = this;
            
        }
        else
        {
            // Me han quitado el trono, por lo tanto, me mato (soy un falso rey)
            Destroy(this.gameObject);
        }
    }

    public void IniciarDialogo(DialogoSO dialogo, Transform cameraPoint)
    {
        Time.timeScale = 0;
        // el dialogo actual es el que tenemos que 
        dialogoActual = dialogo;
        marcoDialogo.SetActive(true);

        //Posiciono la camara en el punto de este NPC.
        //npcCamera.position = cameraPoint.position;
        //npcCamera.rotation = cameraPoint.rotation;
        //Esto es válido pero hay otra manera.
       
        //Posiciono y Roto la camara en el punto de este NPC.
        npcCamera.SetPositionAndRotation(cameraPoint.position, cameraPoint.rotation);

        StartCoroutine(EscribirFrase());
    }

    
    public IEnumerator EscribirFrase()
    {
        escribiendo = true;


        textoDialogo.text = string.Empty;
        //Desmenuzo la frase actual por caracteres por separado
        char[] fraseEnLetras = dialogoActual.frases[indiceFraseActual].ToCharArray();

        foreach(char letra in fraseEnLetras)
        {
            //1. Incluir la letra en el texto
            textoDialogo.text += letra;
            //2. Esperar 0.02 sec
            //WaitForSecondsRealTime no se para si el tiempo está congelado
         
            yield return new WaitForSecondsRealtime(dialogoActual.tiempoEntreLetras);
        }

        escribiendo = false;
    }



    public void CompletarFrase()
    {
        //Si me piden completar la frase entera, en el texto pongo la frase entera
        textoDialogo.text = dialogoActual.frases[indiceFraseActual];
        //paro las corrutinas que puedan estar vivas. 
        StopAllCoroutines();
        escribiendo = false;

    }

    public void SiguienteFrase()
    {
        //Si no estoy escribiendo...
        if (!escribiendo)
        {


            indiceFraseActual++; //Entonces avanzo a la siguiente frase
            //Si aun me quedan frases por sacar
          if(indiceFraseActual < dialogoActual.frases.Length)
          {
                //La Escribo
                StartCoroutine(EscribirFrase());

          }
          else
          {
                FinalizarDialogo();
          }



        }
        else 
        {
            
            CompletarFrase();


        }


    }
    private void FinalizarDialogo()
    {
        marcoDialogo.SetActive(false); //Cerramos el marco de diálogo
        indiceFraseActual = 0; //Para que en posteriores dialogos empezamos desde el indice 0
        escribiendo = false;
        dialogoActual = null; //Ya no tengo diálogo que escribir;
        Time.timeScale = 1;
    }


    //// Update is called once per frame
    ////void Update()
    //{
        
    //}
}
