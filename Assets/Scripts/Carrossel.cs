using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrossel : MonoBehaviour {

	[SerializeField] private VelocidadeCompartilhada velocidadeCompartilhada;

	private Vector3 posicaoInicial;
	private float tamanhoRealDaImagem;

	private void Awake() {

		this.posicaoInicial = this.transform.position;

		float tamanhoDaImagem = this.GetComponent<SpriteRenderer> ().size.x;
		float escalaDaImagem = this.transform.localScale.x;
		this.tamanhoRealDaImagem = tamanhoDaImagem * escalaDaImagem;
	}

	private void Update () {

		// Calcula o deslocamento feito pelo tamanhoRealDaImagem, considerando a velocidade definida e o tempo que levou
		// Repeat varia o número calculado do tamanhoRealDaImagem até zero e repete o calculo
		float deslocamento = Mathf.Repeat ( this.velocidadeCompartilhada.velocidade * Time.time, 
                                            this.tamanhoRealDaImagem/2);    // Dividindo por dois após mudança no Tiling nos sprites de cenário

		// Move a imagem para a esquerda até que o deslocamento ser zerado e ela retornar à poição inicial:
		this.transform.position = this.posicaoInicial + Vector3.left * deslocamento;
	}
}
