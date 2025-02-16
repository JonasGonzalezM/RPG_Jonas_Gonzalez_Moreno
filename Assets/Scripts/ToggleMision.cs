using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMision : MonoBehaviour
{

    private Toggle toggleVisual;

    [SerializeField]
    public Text textoMision;

    public Toggle ToggleVisual { get => toggleVisual; }
    public Text Text { get => textoMision; set => textoMision = value; }

    private void Awake()
    {
        toggleVisual = GetComponent<Toggle>();
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
