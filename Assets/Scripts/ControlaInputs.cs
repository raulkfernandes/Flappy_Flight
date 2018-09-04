using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlaInputs : MonoBehaviour {

    [SerializeField] private KeyCode tecla;
    [SerializeField] UnityEvent aoPressionarTecla;
    
    private void Update()
    {
        if(Input.GetKeyDown(this.tecla))
        {
            // Quando o avião está inativo, impede reconhecimento de Input:
            if(this.gameObject.GetComponent<Rigidbody2D>().simulated == true)
            {
                this.aoPressionarTecla.Invoke();
            }
        }
    }
}