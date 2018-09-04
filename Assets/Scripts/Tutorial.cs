using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

	[SerializeField] [Range (0, 10)] private int contadorDeCliques;

	private SpriteRenderer imagem;
	private int contadorInicial;

	private void Awake () {

		this.imagem = this.GetComponent<SpriteRenderer> ();
		this.contadorInicial = this.contadorDeCliques;
	}

	private void Update () {

		if (Input.GetMouseButtonDown (0) && this.imagem.enabled) {
			this.contadorDeCliques--;
		}

		if (this.contadorDeCliques == 0) {
			this.Desaparecer ();
		}
	}

	public void Desaparecer () {
		
		this.imagem.enabled = false;
	}

	public void Reiniciar () {

		this.imagem.enabled = true;
		this.contadorDeCliques = this.contadorInicial;
	}
}
