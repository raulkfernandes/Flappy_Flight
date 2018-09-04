using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceStandby : MonoBehaviour {

    [SerializeField] private GameObject fundoStandby;
    [SerializeField] private Text textoStandby;
    private Canvas canvas;

    private void Awake()
    {
        this.canvas = this.GetComponent<Canvas>();
    }

    public void Mostrar (Camera camera)
    {
        this.canvas.worldCamera = camera;
        this.fundoStandby.SetActive(true);
    }

    public void Sumir ()
    {
        this.fundoStandby.SetActive(false);
    }

    public void AtualizarTexto (int pontosParaReviver)
    {
        this.textoStandby.text = "Reviver após: " + pontosParaReviver + " pontos!";
    }

    public void AtualizarTextoVersus ()
    {
        this.textoStandby.text = "Errroou!\nMelhor sorte na próxima!";
    }
}
